#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Activities.Presentation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Dev2.Studio.ViewModels.Workflow;


namespace Dev2.Studio.Views.Workflow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WorkflowDesignerView : IWorkflowDesignerView
    {
        readonly DragDropHelpers _dragDropHelpers;

        public WorkflowDesignerView()
        {
            InitializeComponent();
            PreviewDrop += DropPointOnDragEnter;
            PreviewDragOver += DropPointOnDragEnter;
            PreviewMouseDown += WorkflowDesignerViewPreviewMouseDown;
            _dragDropHelpers = new DragDropHelpers(this);
            
        }

        void WorkflowDesignerViewPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof (System.Windows.Documents.Run))
            {
                return;
            }
            if (e.ChangedButton == MouseButton.Right)
            {
                var node = e.OriginalSource as DependencyObject;
                while (node != null)
                {
                    if (node is ActivityDesigner)
                    {
                        break;
                    }
                    if (node.GetType().Name.Contains("StartSymbol"))
                    {
                        RightClickStartNode(e);
                        break;
                    }
                    node = VisualTreeHelper.GetParent(node);
                }
            }
            OnPreviewMouseDown(e);
        }

        private void RightClickStartNode(MouseButtonEventArgs e)
        {
            var rect = e.OriginalSource as System.Windows.Shapes.Rectangle;
            if (e.OriginalSource is Grid grid)
            {
                grid.ContextMenu = WorkflowDesigner.Resources["StartNodeContextMenu"] as ContextMenu;
                if (grid.ContextMenu != null)
                {
                    grid.ContextMenu.IsOpen = true;
                    grid.ContextMenu.DataContext = DataContext;

                }
            }
            else
            {
                if (rect != null)
                {
                    rect.ContextMenu = WorkflowDesigner.Resources["StartNodeContextMenu"] as ContextMenu;
                    if (rect.ContextMenu != null)
                    {
                        rect.ContextMenu.IsOpen = true;
                        rect.ContextMenu.DataContext = DataContext;
                    }
                }
            }
        }

        //a return from here without settings handled to true and DragDropEffects.None implies that the item drop is allowed
        void DropPointOnDragEnter(object sender, DragEventArgs e)
        {
            var dataObject = e.Data;
            var workSurfaceServiceId = ((Core.Models.ResourceModel)
                             ((WorkflowDesignerViewModel)
                             ((FrameworkElement)e.Source)
                             .DataContext).ResourceModel).ID;
            var data = dataObject.GetData("Warewolf.Studio.ViewModels.ExplorerItemViewModel");
            var itemBeingDraggedOntoTheSurface = data as Warewolf.Studio.ViewModels.ExplorerItemViewModel;

            if (e.OriginalSource.GetType() == typeof(ScrollViewer))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
            else if (e.OriginalSource.GetType() == typeof(Border))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
            else if (e.OriginalSource.GetType() == typeof(Grid))
            {
                if (e.OriginalSource is Grid grid && grid.DataContext.GetType() == typeof(WorkflowDesignerViewModel))
                {
                    e.Effects = DragDropEffects.None;
                    e.Handled = true;
                }
            }
            else if (itemBeingDraggedOntoTheSurface != null && workSurfaceServiceId == itemBeingDraggedOntoTheSurface.ResourceId)
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
            else
            {
                if (_dragDropHelpers.PreventDrop(dataObject))
                {
                    e.Effects = DragDropEffects.None;
                    e.Handled = true;
                }
            }
        }
    }
    public interface IWorkflowDesignerView
    {
        object DataContext { get; set; }
    }
}