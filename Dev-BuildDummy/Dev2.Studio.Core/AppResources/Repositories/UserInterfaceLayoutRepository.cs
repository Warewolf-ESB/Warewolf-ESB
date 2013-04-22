﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Dev2.Studio.Core.Interfaces;
using Dev2.Studio.Core.Models;
using Unlimited.Framework;

namespace Dev2.Studio.Core.AppResources.Repositories
{
    [Export(typeof(IFrameworkRepository<UserInterfaceLayoutModel>))]
    public class UserInterfaceLayoutRepository : IFrameworkRepository<UserInterfaceLayoutModel>
    {
        #region Class Members

        private Dictionary<UserInterfaceLayoutModel, string> _userInterfaceLayoutModels;
        public event EventHandler ItemAdded;

        #endregion Class Members

        #region Constructors

        public UserInterfaceLayoutRepository()
        {
            _userInterfaceLayoutModels = new Dictionary<UserInterfaceLayoutModel, string>();
        }

        #endregion Constructors

        #region Properties

        [Import]
        public IFilePersistenceProvider FilePersistenceProvider { get; set; }

        #endregion Properties

        #region Methods

        public ICollection<UserInterfaceLayoutModel> All()
        {
            return _userInterfaceLayoutModels.Keys;
        }

        public ICollection<UserInterfaceLayoutModel> Find(Expression<Func<UserInterfaceLayoutModel, bool>> expression)
        {
            Func<UserInterfaceLayoutModel, bool> func = expression.Compile();
            return All().Where(func).ToList();
        }

        public UserInterfaceLayoutModel FindSingle(Expression<Func<UserInterfaceLayoutModel, bool>> expression)
        {
            Func<UserInterfaceLayoutModel, bool> func = expression.Compile();
            return All().FirstOrDefault(func);
        }

        public void Save(UserInterfaceLayoutModel instanceObj)
        {
            if (instanceObj == null) return;

            string file;
            if (_userInterfaceLayoutModels.TryGetValue(instanceObj, out file))
            {
                if (Path.GetFileNameWithoutExtension(file) != instanceObj.LayoutName)
                {
                    DirectoryInfo di = new DirectoryInfo(file);
                    string newFile = Path.Combine(di.FullName, instanceObj.LayoutName + ".xml");

                    if (File.Exists(newFile))
                    {
                        throw new Exception("Layout with that name already exists.");
                    }

                    FilePersistenceProvider.Delete(file);

                    _userInterfaceLayoutModels[instanceObj] = newFile;
                    file = newFile;
                }
            }
            else
            {
                string path = GetLayoutDirectory();

                DirectoryInfo di = new DirectoryInfo(path);
                if (!di.Exists)
                {
                    di.Create();
                }

                string newFile = Path.Combine(di.FullName, instanceObj.LayoutName + ".xml");
                _userInterfaceLayoutModels.Add(instanceObj, newFile);
                file = newFile;

                OnItemAdded(instanceObj);
            }

            FilePersistenceProvider.Write(file, instanceObj.MainViewDockingData);
        }

        public void Save(ICollection<UserInterfaceLayoutModel> instanceObjs)
        {
            foreach (UserInterfaceLayoutModel userInterfaceLayoutModel in instanceObjs)
            {
                Save(userInterfaceLayoutModel);
            }
        }

        public void Load()
        {
            _userInterfaceLayoutModels.Clear();

            foreach (string file in GetLayoutFiles())
            {
                UserInterfaceLayoutModel userInterfaceLayoutModel = ModelFromFile(file);
                if (userInterfaceLayoutModel != null)
                {
                    _userInterfaceLayoutModels.Add(userInterfaceLayoutModel, file);
                }
            }
        }

        public void Remove(UserInterfaceLayoutModel instanceObj)
        {
            if (instanceObj == null) return;

            string file;
            if (_userInterfaceLayoutModels.TryGetValue(instanceObj, out file) && File.Exists(file))
            {
                FilePersistenceProvider.Delete(file);
                _userInterfaceLayoutModels.Remove(instanceObj);
            }
        }

        public void Remove(ICollection<UserInterfaceLayoutModel> instanceObjs)
        {
            foreach (UserInterfaceLayoutModel userInterfaceLayoutModel in instanceObjs)
            {
                Remove(userInterfaceLayoutModel);
            }
        }

        #endregion Methods

        #region Private Methods

        private string[] GetLayoutFiles()
        {
            string path = GetLayoutDirectory();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return Directory.GetFiles(path);
        }

        private static string GetLayoutDirectory()
        {
            string path = Path.Combine(new string[] 
                { 
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                    StringResources.App_Data_Directory, 
                    StringResources.User_Interface_Layouts_Directory 
                });

            return path;
        }

        private UserInterfaceLayoutModel ModelFromFile(string file)
        {
            UserInterfaceLayoutModel userInterfaceLayoutModel = null;

            if (FilePersistenceProvider != null)
            {
                userInterfaceLayoutModel = new UserInterfaceLayoutModel();
                userInterfaceLayoutModel.LayoutName = Path.GetFileNameWithoutExtension(file);
                userInterfaceLayoutModel.MainViewDockingData = FilePersistenceProvider.Read(file);
            }
            return userInterfaceLayoutModel;
        }

        #endregion Private Methods

        #region Protected Methods

        protected void OnItemAdded(object sender)
        {
            if (ItemAdded != null)
            {
                ItemAdded.Invoke(sender, new System.EventArgs());
            }
        }

        #endregion Protected Methods
    }
}
