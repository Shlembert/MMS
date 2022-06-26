#if UNITY_IOS
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

namespace Editor
{
    public static class ChangeInfoPlistPostProcessingBuild 
    {
        [PostProcessBuild]
        public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToProject)
        {
            if(buildTarget != BuildTarget.iOS) return;
        
            string plistPath = pathToProject + "/Info.plist";
            PlistDocument plist = new PlistDocument();
            plist.ReadFromFile(plistPath);
        
            PlistElementDict rootDict = plist.root;
        
            //Сюда можно вписать все заввисимости которые хотим добавить в Info.plist
            rootDict.SetString("NSPhotoLibraryAddUsageDescription", "Save to photo album?");
        
            File.WriteAllText(plistPath, plist.WriteToString());
        }
    }
}
#endif