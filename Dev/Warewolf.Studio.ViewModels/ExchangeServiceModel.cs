﻿using System.Collections.ObjectModel;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Data;
using Dev2.Common.Interfaces.ToolBase.ExchangeEmail;

namespace Warewolf.Studio.ViewModels
{
    public class ExchangeServiceModel : IExchangeServiceModel
    {
        readonly IStudioUpdateManager _updateRepository;
        readonly IQueryManager _queryProxy;
        readonly IShellViewModel _shell;

        public ExchangeServiceModel(IStudioUpdateManager updateRepository, IQueryManager queryProxy, IShellViewModel shell, IServer server)
        {
            _updateRepository = updateRepository;
            _queryProxy = queryProxy;
            _shell = shell;
            shell.SetActiveServer(server);
        }
        public ObservableCollection<IExchangeSource> RetrieveSources()
        {
            return new ObservableCollection<IExchangeSource>(_queryProxy.FetchExchangeSources());
        }

        public void CreateNewSource()
        {
            _shell.NewResource("ExchangeSource", "");
        }

        public void EditSource(IExchangeSource selectedSource)
        {
            _shell.EditResource(selectedSource);
        }

        public void SaveService(IExchangeSource model)
        {
            _updateRepository.Save(model);
        }

        public IStudioUpdateManager UpdateRepository
        {
            get
            {
                return _updateRepository;
            }
        }
    }
}
