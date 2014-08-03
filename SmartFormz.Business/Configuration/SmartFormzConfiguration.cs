using System.Configuration;

namespace SmartFormz.Business.Configuration
{
    public sealed class SmartFormzConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("connectionString", IsRequired=true)]
        public string ConnectionString
        {
            get { return this["connectionString"].ToString(); }
            set { this["connectionString"] = value; }
        }
    }
}
