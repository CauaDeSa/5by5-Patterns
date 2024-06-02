using Service;

namespace Controller
{
    public class ViewController
    {
        private readonly SmartReferralProxy _smartReferralProxy = new();
        public static readonly string Sql = "SQL";
        public static readonly string Mongo = "MONGO";

        public string GetCsvFromSql()
        {
            _smartReferralProxy.SetProxy(Sql);

            return CsvRadarAdapter.ToString(_smartReferralProxy.RetrieveAll());
        }

        public string GetXmlFromSql()
        { 
            _smartReferralProxy.SetProxy(Sql);
 
            return XmlRadarAdapter.ToString(_smartReferralProxy.RetrieveAll());
        }

        public string GetJsonFromSql()
        {
            _smartReferralProxy.SetProxy(Sql);

            return JsonRadarAdapter.ToString(_smartReferralProxy.RetrieveAll());
        }

        public string GetCsvFromMongo()
        {
            _smartReferralProxy.SetProxy(Mongo);

            return CsvRadarAdapter.ToString(_smartReferralProxy.RetrieveAll());
        }

        public string GetXmlFromMongo()
        {
            _smartReferralProxy.SetProxy(Mongo);

            return XmlRadarAdapter.ToString(_smartReferralProxy.RetrieveAll());
        }

        public string GetJsonFromMongo()
        {
            _smartReferralProxy.SetProxy(Mongo);

            return JsonRadarAdapter.ToString(_smartReferralProxy.RetrieveAll());
        }
    }
}