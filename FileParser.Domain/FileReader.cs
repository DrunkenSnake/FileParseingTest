using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FileParser.Domain.Entities;
using Newtonsoft.Json;

namespace FileParser.Domain
{
    public class FileReader
    {
        #region Fields

        private readonly JsonSerializerSettings _settings;//settings used throughout deserialization

        #endregion Fields

        #region Constructors

        public FileReader() : this(new JsonSerializerSettings//default constructor
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            }){ }

        public FileReader(JsonSerializerSettings settings)//incase it wants to be called with different settings
        {
            _settings = settings;
        }

        #endregion Constructors

        #region Methods

        #region Public

        public IEnumerable<Menu> GetMenuFromFilePath(string filePath)
        {
            string fileText;
            using (var reader = new StreamReader(filePath, true))//stream reader, autodetects encoding
            {
                fileText = reader.ReadToEnd();
            }
            var menus = JsonConvert.DeserializeObject<Wrap[]>(fileText, _settings);//deserializes file contents to menus list
            return menus.Select(menu => menu.Menu).ToList();
        }

        #endregion Public

        #region Private



        #endregion Private

        #endregion Methods
    }
}
