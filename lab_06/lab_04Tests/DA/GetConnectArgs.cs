using DA;

namespace Tests.DA
{
    public static class GetConnectArgs
    {
        public static ConnectionArgs getarg()
        {
            return new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432); 
        }
    }
}
