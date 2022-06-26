using System;
using System.IO;
using System.IO.Compression;
using UnityEngine;

namespace Utility
{
    public class FileZipCreator
    {
        //Это название можете поменять если хотите, это чисто название общей папки где будут храниться созданные паки
        private const string DIRECTORY_NAME_ROOT = "MineCraftPacks"; 
        
        private const string DIRECTORY_NAME_TEXTS = "texts";
        private const string FILE_NAME_LOCALIZATION = "en_US.lang";
        private const string FILE_NAME_MANIFEST = "manifest.json";
        private const string FILE_NAME_SKINS = "skins.json";
        
        /// <summary>
        /// Метод создания зип файла разрешения .mcpack
        /// </summary>
        /// <param name="pathToFile">Путь к файлу скина на девайсе</param>
        /// <param name="filePackName">Имя которое будет присвоенно файлу</param>
        /// <param name="imageName">Имя картинки без расшерение (.png)</param>
        /// <returns>Возвращает путь к готовому зип файлу</returns>
        public string CreateSkinFile(string pathToFile, string filePackName, string imageName)
        {
            string directoryName = Application.persistentDataPath;
            
            string fileName = filePackName;

            string pathToFileEnd = Path.Combine(directoryName, DIRECTORY_NAME_ROOT);
            
            if (!Directory.Exists(pathToFileEnd))
                Directory.CreateDirectory(pathToFileEnd);

            pathToFileEnd = Path.Combine(pathToFileEnd, fileName);
            
            if (!Directory.Exists(pathToFileEnd))
                Directory.CreateDirectory(pathToFileEnd);
            
            if (!Directory.Exists(Path.Combine(pathToFileEnd, DIRECTORY_NAME_TEXTS)))
                Directory.CreateDirectory(Path.Combine(pathToFileEnd, DIRECTORY_NAME_TEXTS));

            ManifestJson manifestJson = new ManifestJson
            {
                format_version = 1,
                header = new HeaderJson {name = fileName, uuid = Guid.NewGuid().ToString(), version = new[] {1, 0, 0}},
                modules = new[]
                {
                    new ModuleJson {type = "skin_pack", uuid = Guid.NewGuid().ToString(), version = new[] {1, 0, 0}}
                }
            };
            SkinsJson skinsJson = new SkinsJson
            {
                skins = new []{new SkinJson
                {
                    localization_name = "current",
                    geometry = $"geometry.{fileName}.current",
                    texture = imageName + ".png",
                    type = "free"
                }},
                serialize_name = fileName,
                localization_name = fileName
            };

            string oneStringInLoc = $"skinpack.{fileName}={fileName}";
            string twoStringInLoc = $"skin.{fileName}.current=current";

            string inFileLoc = oneStringInLoc + "\n" + twoStringInLoc;
            
            if(!File.Exists(Path.Combine(pathToFileEnd, DIRECTORY_NAME_TEXTS, FILE_NAME_LOCALIZATION)))
                File.WriteAllText(Path.Combine(pathToFileEnd, DIRECTORY_NAME_TEXTS, FILE_NAME_LOCALIZATION), inFileLoc);
           
            if(!File.Exists(Path.Combine(pathToFileEnd, FILE_NAME_MANIFEST)))
                File.WriteAllText(Path.Combine(pathToFileEnd, FILE_NAME_MANIFEST), JsonUtility.ToJson(manifestJson));
           
            if(!File.Exists(Path.Combine(pathToFileEnd, FILE_NAME_SKINS)))
                File.WriteAllText(Path.Combine(pathToFileEnd, FILE_NAME_SKINS), JsonUtility.ToJson(skinsJson));
            
            if(File.Exists(pathToFile))
                File.Copy(pathToFile, Path.Combine(pathToFileEnd, imageName + ".png"));

            return ConvertToZipFile(pathToFileEnd, fileName);
        }

        private string ConvertToZipFile(string pathTopDirectory, string fileName)
        {
            string finalPackPath = pathTopDirectory + fileName + ".mcpack";
            if(Directory.Exists(pathTopDirectory))
            {
                if(!File.Exists(finalPackPath))
                    ZipFile.CreateFromDirectory(pathTopDirectory, finalPackPath);
                
                DeleteDirectory(pathTopDirectory);
            }
            return finalPackPath;
        }

        private void DeleteDirectory(string pathToDirectory)
        {
            string[] files = Directory.GetFiles(pathToDirectory);
            string[] dirs = Directory.GetDirectories(pathToDirectory);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(pathToDirectory, false);
        }
        
        [Serializable]
        public class ManifestJson
        {
            public int format_version;
            
            public HeaderJson header;
            
            public ModuleJson[] modules;
        }
        [Serializable]
        public class HeaderJson
        {
            public string name;
            public string uuid;
            
            public int[] version;
        }
        [Serializable]
        public class ModuleJson
        {
            public string type;
            public string uuid;
            
            public int[] version;
        }

        [Serializable]
        public class SkinsJson
        {
            public SkinJson[] skins;
            public string serialize_name;
            public string localization_name;
        }

        [Serializable]
        public class SkinJson
        {
            public string localization_name;
            public string geometry;
            public string texture;
            public string type;
        }
    }
}