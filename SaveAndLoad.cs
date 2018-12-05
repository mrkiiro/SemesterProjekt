using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Windows.Data.Json;
using Windows.Storage;
using Windows.Storage.Streams;
using GalaSoft.MvvmLight.Messaging;

namespace App8
{
    public static class SaveAndLoad<T>
    {
        private static readonly StorageFolder _folder = Windows.Storage.ApplicationData.Current.LocalFolder;

        public static async Task<T> Load(string fileName)
        {
            StorageFile jsonFile = await _folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));

            using (Stream stream = await jsonFile.OpenStreamForReadAsync())
            {
                return (T)jsonSerializer.ReadObject(stream);
            }
        }

        public static async void Save(T objectToSave, string fileName)
        {
            StorageFile jsonFile = await _folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));

            using (Stream stream = await jsonFile.OpenStreamForWriteAsync())
            {
                jsonSerializer.WriteObject(stream, objectToSave);
            }
        }

    }
}
