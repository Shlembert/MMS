#if UNITY_IOS
using System.Runtime.InteropServices;

namespace IOSBridge
{
    public static class IOStoUnityBridge
    {
        [DllImport("__Internal")]
        private static extern void _showAlert(string title, string message);
        
        [DllImport("__Internal")]
        private static extern void _initWithActivity(string pathToMode);
        
        [DllImport("__Internal")]
        private static extern void _saveImageToAlbum(string pathToImage);
        
        [DllImport("__Internal")]
        private static extern void _showActionSheet(string objectName, string methodName);
        [DllImport("__Internal")]
        private static extern void _showAlertWithCallBack(string title, string message, string objectName, string action);

        /// <summary>
        /// Метод вызова отправки файла в майнкрфат
        /// </summary>
        /// <param name="pathToMode">путь к файлу мода</param>
        public static void InitWithActivity(string pathToMode)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _initWithActivity(pathToMode);
#endif
        } 
        
        /// <summary>
        /// Показывает всплывающее окошко с написями
        /// </summary>
        /// <param name="title">Надпись что будет на заголовке</param>
        /// <param name="message">Надпись описания</param>
        public static void ShowAlert(string title, string message)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _showAlert(title, message);
#endif
        }
        
        /// <summary>
        /// Сохранения картинки в галерею
        /// </summary>
        /// <param name="pathToImage">путь к картинке на телефоне</param>
        public static void SaveImageToAlbum(string pathToImage)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _saveImageToAlbum(pathToImage);
#endif
        } 
        
        public static void ShowActionSheet(string objectName, string methodName)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _showActionSheet(objectName, methodName);
#endif
        } 
        
        /// <summary>
        /// Показывает окошко с предупреждением 
        /// </summary>
        /// <param name="title">Текст что будет выводиться в заголовке</param>
        /// <param name="message">Текст что будет выводиться в описании</param>
        /// <param name="objectName">Имя геймобжикта на сцене у котором лежит вызываемый класс и метод</param>
        /// <param name="action">Имя метода что будет вызван</param>
        public static void ShowAlertWithCallBack(string title, string message, string objectName, string action)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _showAlertWithCallBack(title, message, objectName, action);
#endif
        } 
    }
}
#endif