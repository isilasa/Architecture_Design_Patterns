using System.Collections.Concurrent;

namespace HomeWork.Resolvers
{
    public static class IoC
    {
        private static readonly ConcurrentDictionary<string, Func<object[], object>> globalRegistrations =
            new ConcurrentDictionary<string, Func<object[], object>>();

        private static readonly ConcurrentDictionary<string, ThreadLocal<Dictionary<string, Func<object[], object>>>> scopes =
            new ConcurrentDictionary<string, ThreadLocal<Dictionary<string, Func<object[], object>>>>();

        private static readonly ThreadLocal<string> currentScopeId = new ThreadLocal<string>(() => null);

        public static T Resolve<T>(string key, params object[] args)
        {
            if (key == "IoC.Register")
            {
                var regKey = args[0] as string;
                var creator = args[1] as Func<object[], object>;
                Register(regKey, creator);
                return default;
            }
            if (key == "Scopes.New")
            {
                var scopeId = args[0] as string;
                CreateScope(scopeId);
                return default;
            }
            if (key == "Scopes.Current")
            {
                var scopeId = args[0] as string;
                SetCurrentScope(scopeId);
                return default;
            }

            var scopeDict = GetCurrentScopeDictionary();
            if (scopeDict != null && scopeDict.TryGetValue(key, out var scopeCreator))
            {
                return (T)scopeCreator(args);
            }

            if (globalRegistrations.TryGetValue(key, out var globalCreator))
            {
                return (T)globalCreator(args);
            }

            throw new Exception($"Зависимость '{key}' не зарегистрирована");
        }

        private static void Register(string key, Func<object[], object> creator)
        {
            globalRegistrations[key] = creator;
        }

        public static void CreateScope(string scopeId)
        {
            var scopeDict = new Dictionary<string, Func<object[], object>>();
            var threadLocalScope = new ThreadLocal<Dictionary<string, Func<object[], object>>>(() => scopeDict);
            scopes[scopeId] = threadLocalScope;
        }

        public static void SetCurrentScope(string scopeId)
        {
            if (!scopes.ContainsKey(scopeId))
                throw new Exception($"Скоуп {scopeId} не существует");
            currentScopeId.Value = scopeId;
        }

        private static Dictionary<string, Func<object[], object>> GetCurrentScopeDictionary()
        {
            var scopeId = currentScopeId.Value;
            if (scopeId == null)
                return null;
            if (scopes.TryGetValue(scopeId, out var threadScope))
            {
                return threadScope.Value;
            }
            return null;
        }
    }
}