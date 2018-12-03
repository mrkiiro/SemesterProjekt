using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Streams;
using GalaSoft.MvvmLight.Messaging;

namespace App8
{
    public static class SaveAndLoad<T>
    {
        private static readonly StorageFolder _folder = Windows.Storage.ApplicationData.Current.LocalFolder;

        public static async Task<List<T>> Load(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            StorageFile file = await _folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            List<T> loadedList = new List<T>();
            using (var stream = file.OpenStreamForWriteAsync().Result)
            {
                loadedList = (List<T>)xs.Deserialize(stream);
            }
            return loadedList;
        }

        public static async void Save(T objectToSave, string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            StorageFile file = await _folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            using (var stream = file.OpenStreamForWriteAsync().Result)
            {
                xs.Serialize(stream, objectToSave);
            }
        }

    }
}
