﻿using Dev2.DataList.Contract;
using Dev2.Studio.Core.Interfaces;
using Dev2.Studio.InterfaceImplementors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Dev2.UI
{
    /// <summary>
    /// PBI 1214
    /// Awesome Cake IntellisenseTextBox
    /// </summary>
    public class IntellisenseTextBox : TextBox, INotifyPropertyChanged
    {
        #region Static Constructor
        static IntellisenseTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IntellisenseTextBox), 
                new FrameworkPropertyMetadata(typeof(IntellisenseTextBox)));
        }
        #endregion Static Constructor

        #region Static Members
        private static void ScrollIntoViewCentered(ListBox listBox, object item)
        {
            FrameworkElement container = listBox.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;

            if (container != null)
            {
                if (ScrollViewer.GetCanContentScroll(listBox))
                {
                    IScrollInfo scrollInfo = VisualTreeHelper.GetParent(container) as IScrollInfo;

                    if (null != scrollInfo)
                    {
                        StackPanel stackPanel = scrollInfo as StackPanel;
                        VirtualizingStackPanel virtualizingStackPanel = scrollInfo as VirtualizingStackPanel;
                        int index = listBox.ItemContainerGenerator.IndexFromContainer(container);

                        if ((stackPanel != null && Orientation.Horizontal == stackPanel.Orientation) || (virtualizingStackPanel != null && Orientation.Horizontal == virtualizingStackPanel.Orientation))
                        {
                            scrollInfo.SetHorizontalOffset(index - (int)(scrollInfo.ViewportWidth / 2));
                        }
                        else
                        {
                            scrollInfo.SetVerticalOffset(index - (int)(scrollInfo.ViewportHeight / 2));
                        }
                    }
                }
                else
                {
                    Rect rect = new Rect(new Point(), container.RenderSize);

                    FrameworkElement constrainingParent = container;
                    do
                    {
                        constrainingParent = VisualTreeHelper.GetParent(constrainingParent) as FrameworkElement;
                    }
                    while (constrainingParent != null && listBox != constrainingParent && !(constrainingParent is ScrollContentPresenter));

                    if (null != constrainingParent)
                    {
                        rect.Inflate(Math.Max((constrainingParent.ActualWidth - rect.Width) / 2, 0), Math.Max((constrainingParent.ActualHeight - rect.Height) / 2, 0));
                    }

                    container.BringIntoView(rect);
                }
            }
        }
        #endregion

        #region Routed Events

        #region OpenedEvent
        public static readonly RoutedEvent OpenedEvent = EventManager.RegisterRoutedEvent("Opened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(IntellisenseTextBox));

        public event RoutedEventHandler Opened
        {
            add
            {
                AddHandler(OpenedEvent, value);
            }
            remove
            {
                RemoveHandler(OpenedEvent, value);
            }
        }
        #endregion OpenedEvent

        #region TabInsertedEvent
        public static readonly RoutedEvent TabInsertedEvent = EventManager.RegisterRoutedEvent("TabInserted", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(IntellisenseTextBox));

        public event RoutedEventHandler TabInserted
        {
            add
            {
                AddHandler(TabInsertedEvent, value);
            }
            remove
            {
                RemoveHandler(TabInsertedEvent, value);
            }
        }
        #endregion TabInsertedEvent

        #region ClosedEvent
        public static readonly RoutedEvent ClosedEvent = EventManager.RegisterRoutedEvent("Closed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(IntellisenseTextBox));

        public event RoutedEventHandler Closed
        {
            add
            {
                AddHandler(ClosedEvent, value);
            }
            remove
            {
                RemoveHandler(ClosedEvent, value);
            }
        }
        #endregion ClosedEvent

        #endregion Routed Events

        #region Dependency Properties

        #region HasError
        public static readonly DependencyProperty HasErrorProperty = DependencyProperty.Register("HasError", typeof(bool), typeof(IntellisenseTextBox), new PropertyMetadata(false));

        public bool HasError
        {
            get
            {
                return (bool)GetValue(HasErrorProperty);
            }
            set
            {
                SetValue(HasErrorProperty, value);
            }
        }

        #endregion HasError

        #region SelectAllOnGotFocus
        public static readonly DependencyProperty SelectAllOnGotFocusProperty = DependencyProperty.Register("SelectAllOnGotFocus", typeof(bool), typeof(IntellisenseTextBox), new PropertyMetadata(false));

        public bool SelectAllOnGotFocus
        {
            get
            {
                return (bool)GetValue(SelectAllOnGotFocusProperty);
            }
            set
            {
                SetValue(SelectAllOnGotFocusProperty, value);
            }
        }

        #endregion SelectAllOnGotFocus

        #region AllowMultilinePaste
        public static readonly DependencyProperty AllowMultilinePasteProperty = DependencyProperty.Register("AllowMultilinePaste", typeof(bool), typeof(IntellisenseTextBox), new PropertyMetadata(true, OnAllowMultilinePasteChanged));

        public bool AllowMultilinePaste
        {
            get
            {
                return (bool)GetValue(AllowMultilinePasteProperty);
            }
            set
            {
                SetValue(AllowMultilinePasteProperty, value);
            }
        }

        private static void OnAllowMultilinePasteChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            IntellisenseTextBox box = sender as IntellisenseTextBox;

            if (box != null)
            {
                box.OnAllowMultilinePasteChanged((bool)args.OldValue, (bool)args.NewValue);
            }
        }
        #endregion AllowMultilinePaste

        #region AllowUserInsertLine
        public static readonly DependencyProperty AllowUserInsertLineProperty = DependencyProperty.Register("AllowUserInsertLine", typeof(bool), typeof(IntellisenseTextBox), new PropertyMetadata(true, OnAllowUserInsertLineChanged));

        public bool AllowUserInsertLine
        {
            get
            {
                return (bool)GetValue(AllowUserInsertLineProperty);
            }
            set
            {
                SetValue(AllowUserInsertLineProperty, value);
            }
        }

        private static void OnAllowUserInsertLineChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            IntellisenseTextBox box = sender as IntellisenseTextBox;

            if (box != null)
            {
                box.OnAllowUserInsertLineChanged((bool)args.OldValue, (bool)args.NewValue);
            }
        }
        #endregion AllowUserInsertLine

        #region AllowUserCalculateMode
        public static readonly DependencyProperty AllowUserCalculateModeProperty = DependencyProperty.Register("AllowUserCalculateMode", typeof(bool), typeof(IntellisenseTextBox), new PropertyMetadata(false, OnAllowUserCalculateModeChanged));

        public bool AllowUserCalculateMode
        {
            get
            {
                return (bool)GetValue(AllowUserCalculateModeProperty);
            }
            set
            {
                SetValue(AllowUserCalculateModeProperty, value);
            }
        }

        private static void OnAllowUserCalculateModeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            IntellisenseTextBox box = sender as IntellisenseTextBox;

            if (box != null)
            {
                box.OnAllowUserCalculateModeChanged((bool)args.OldValue, (bool)args.NewValue);
            }
        }
        #endregion AllowUserCalculateMode

        #region IsInCalculateMode
        public static readonly DependencyProperty IsInCalculateModeProperty = DependencyProperty.Register("IsInCalculateMode", typeof(bool), typeof(IntellisenseTextBox), new PropertyMetadata(false, OnIsInCalculateModeChanged));

        public bool IsInCalculateMode
        {
            get
            {
                return (bool)GetValue(IsInCalculateModeProperty);
            }
            set
            {
                SetValue(IsInCalculateModeProperty, value);
            }
        }

        private static void OnIsInCalculateModeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            IntellisenseTextBox box = sender as IntellisenseTextBox;

            if (box != null)
            {
                box.OnIsInCalculateModeChanged((bool)args.OldValue, (bool)args.NewValue);
            }
        }
        #endregion IsInCalculateMode

        #region DefaultText
        public static readonly DependencyProperty DefaultTextProperty = DependencyProperty.Register("DefaultText", typeof(object), typeof(IntellisenseTextBox), new UIPropertyMetadata(null));

        public object DefaultText
        {
            get
            {
                return (object)GetValue(DefaultTextProperty);
            }
            set
            {
                SetValue(DefaultTextProperty, value);
            }
        }

        #endregion DefaultText

        #region DefaultTextTemplate
        public static readonly DependencyProperty DefaultTextTemplateProperty = DependencyProperty.Register("DefaultTextTemplate", typeof(DataTemplate), typeof(IntellisenseTextBox), new UIPropertyMetadata(null));

        public DataTemplate DefaultTextTemplate
        {
            get
            {
                return (DataTemplate)GetValue(DefaultTextTemplateProperty);
            }
            set
            {
                SetValue(DefaultTextTemplateProperty, value);
            }
        }
        #endregion DefaultTextTemplate

        #region FilterType
        public static readonly DependencyProperty FilterTypeProperty = DependencyProperty.Register("FilterType", typeof(enIntellisensePartType), typeof(IntellisenseTextBox), new UIPropertyMetadata(enIntellisensePartType.All));

        public enIntellisensePartType FilterType
        {
            get
            {
                return (enIntellisensePartType)GetValue(FilterTypeProperty);
            }
            set
            {
                SetValue(FilterTypeProperty, value);
            }
        }

        #endregion FilterType

        #region WrapInBrackets
        public static readonly DependencyProperty WrapInBracketsProperty = DependencyProperty.Register("WrapInBrackets", typeof(bool), typeof(IntellisenseTextBox), new UIPropertyMetadata(false));

        public bool WrapInBrackets
        {
            get
            {
                return (bool)GetValue(WrapInBracketsProperty);
            }
            set
            {
                SetValue(WrapInBracketsProperty, value);
            }
        }

        #endregion WrapInBracketse

        #region IntellisenseProvider
        public static readonly DependencyProperty IntellisenseProviderProperty = DependencyProperty.Register("IntellisenseProvider", typeof(IIntellisenseProvider), typeof(IntellisenseTextBox), new PropertyMetadata(null, OnIntellisenseProviderChanged));

        public IIntellisenseProvider IntellisenseProvider
        {
            get
            {
                return (IIntellisenseProvider)GetValue(IntellisenseProviderProperty);
            }
            set
            {
                SetValue(IntellisenseProviderProperty, value);
            }
        }

        private static void OnIntellisenseProviderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            IntellisenseTextBox box = sender as IntellisenseTextBox;

            if (box != null)
            {
                box.OnIntellisenseProviderChanged((IIntellisenseProvider)args.OldValue, (IIntellisenseProvider)args.NewValue);
            }
        }
        #endregion IntellisenseProvider

        #region ItemsPanel
        public static readonly DependencyProperty ItemsPanelProperty = ItemsControl.ItemsPanelProperty.AddOwner(typeof(IntellisenseTextBox));

        public ItemsPanelTemplate ItemsPanel
        {
            get
            {
                return (ItemsPanelTemplate)GetValue(ItemsPanelProperty);
            }
            set
            {
                SetValue(ItemsPanelProperty, value);
            }
        }
        #endregion ItemsPanel

        #region ItemTemplate
        public static readonly DependencyProperty ItemTemplateProperty = ItemsControl.ItemTemplateProperty.AddOwner(typeof(IntellisenseTextBox));

        public DataTemplate ItemTemplate
        {
            get
            {
                return (DataTemplate)GetValue(ItemTemplateProperty);
            }
            set
            {
                SetValue(ItemTemplateProperty, value);
            }
        }
        #endregion ItemTemplate

        #region ItemTemplateSelector
        public static readonly DependencyProperty ItemTemplateSelectorProperty = ItemsControl.ItemTemplateSelectorProperty.AddOwner(typeof(IntellisenseTextBox));

        public DataTemplateSelector ItemTemplateSelector
        {
            get
            {
                return (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty);
            }
            set
            {
                SetValue(ItemTemplateSelectorProperty, value);
            }
        }
        #endregion ItemTemplateSelector

        #region ItemsSource
        public static readonly DependencyProperty ItemsSourceProperty = ItemsControl.ItemsSourceProperty.AddOwner(typeof(IntellisenseTextBox));

        public IEnumerable ItemsSource
        {
            get
            {
                return (IEnumerable)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }
        #endregion ItemsSource

        #region SelectionMode
        public static readonly DependencyProperty SelectionModeProperty = ListBox.SelectionModeProperty.AddOwner(typeof(IntellisenseTextBox));

        public SelectionMode SelectionMode
        {
            get
            {
                return (SelectionMode)GetValue(SelectionModeProperty);
            }
            set
            {
                SetValue(SelectionModeProperty, value);
            }
        }
        #endregion SelectionMode

        #region SelectedItems
        public static readonly DependencyProperty SelectedItemsProperty = ListBox.SelectedItemsProperty;

        public IList SelectedItems { get { return _listBox.SelectedItems; } }
        #endregion SelectedItems

        #region SelectedValue
        public static readonly DependencyProperty SelectedValueProperty = ListBox.SelectedValueProperty.AddOwner(typeof(IntellisenseTextBox));

        public object SelectedValue
        {
            get
            {
                return GetValue(SelectedValueProperty);
            }
            set
            {
                SetValue(SelectedValueProperty, value);
            }
        }
        #endregion SelectedValue

        #region SelectedItem
        public static readonly DependencyProperty SelectedItemProperty = ListBox.SelectedItemProperty.AddOwner(typeof(IntellisenseTextBox));

        public object SelectedItem
        {
            get
            {
                return GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }
        #endregion SelectedItem

        #region SelectedIndex
        public static readonly DependencyProperty SelectedIndexProperty = ListBox.SelectedIndexProperty.AddOwner(typeof(IntellisenseTextBox));

        public int SelectedIndex
        {
            get
            {
                return (int)GetValue(SelectedIndexProperty);
            }
            set
            {
                SetValue(SelectedIndexProperty, value);
            }
        }
        #endregion SelectedIndex

        #region DisplayMemberPath
        public static readonly DependencyProperty DisplayMemberPathProperty = ItemsControl.DisplayMemberPathProperty.AddOwner(typeof(IntellisenseTextBox));

        public string DisplayMemberPath
        {
            get
            {
                return (string)GetValue(DisplayMemberPathProperty);
            }
            set
            {
                SetValue(DisplayMemberPathProperty, value);
            }
        }
        #endregion DisplayMemberPath

        #region IsOpen
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(IntellisenseTextBox), new UIPropertyMetadata(false, OnIsOpenChanged));

        public bool IsOpen
        {
            get
            {
                return (bool)GetValue(IsOpenProperty);
            }
            set
            {
                SetValue(IsOpenProperty, value);
            }
        }

        private static void OnIsOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            IntellisenseTextBox box = o as IntellisenseTextBox;

            if (box != null)
            {
                box.OnIsOpenChanged((bool)e.OldValue, (bool)e.NewValue);
            }
        }
        #endregion IsOpen

        #endregion Dependency Properties

        #region Instance Fields
        private ListBox _listBox;
        private KeyValuePair<int, int> _lastResultInputKey;
        private bool _lastResultHasError;
        private bool _expectOpen;
        private bool _suppressChangeOpen;
        private IntellisenseDesiredResultSet _desiredResultSet;
        private int _possibleCaretPositionOnPopup = 0;
        private int _caretPositionOnPopup;
        private string _textOnPopup;
        private object _cachedState;

        private ToolTip _toolTip;
        private bool _forcedOpen;
        private bool _fromPopup;
        #endregion

        #region Public Properties
        public ItemCollection Items { get { return _listBox.Items; } }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public IntellisenseTextBox()
        {
            DefaultStyleKey = typeof(IntellisenseTextBox);
            Mouse.AddPreviewMouseDownOutsideCapturedElementHandler(this, OnMouseDownOutsideCapturedElement);
            Unloaded += OnUnloaded;

            DataObject.AddPastingHandler(this, OnPaste);

            //08.04.2013: Ashley Lewis - To test for Bug 9238 Moved this from OnInitialized() to allow for a more contextless initialization
            _toolTip = new ToolTip();
            _listBox = new ListBox();
        }

        #endregion

        #region Load Handling
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            _toolTip.ToolTipOpening += ToolTip_ToolTipOpening;
            ToolTip = _toolTip;

            _toolTip.Placement = PlacementMode.Right;
            _toolTip.PlacementTarget = this;
            EnsureIntellisenseProvider();
        }

        private void ToolTip_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            if (!_fromPopup && IsOpen)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Unloaded Handeling

        private void OnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Unloaded -= OnUnloaded;

        }

        #endregion Unloaded Handeling

        #region Template Handling
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //if (_listBox != null) _listBox.MouseLeftButtonUp -= new MouseButtonEventHandler(ListBox_MouseLeftButtonUp);

            _listBox = GetTemplateChild("PART_ItemList") as ListBox;
            //_listBox.MouseLeftButtonUp += new MouseButtonEventHandler(ListBox_MouseLeftButtonUp);
        }
        #endregion

        #region Paste Handeling

        void OnPaste(object sender, DataObjectPastingEventArgs dataObjectPastingEventArgs)
        {
            var isText = dataObjectPastingEventArgs.SourceDataObject.GetDataPresent(DataFormats.Text, true);
            if(!isText) return;

            var text = dataObjectPastingEventArgs.SourceDataObject.GetData(DataFormats.Text) as string;

            if(text.Contains("\t"))
            {
                RaiseRoutedEvent(TabInsertedEvent);
            }
        }

        #endregion


        #region Event Handling
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            base.OnPreviewTextInput(e);

            if (!_suppressChangeOpen)
            {
                _possibleCaretPositionOnPopup = CaretIndex;
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            try
            {
                if (AllowUserInsertLine && GetLastVisibleLineIndex() + 1 == LineCount)
                {
                    double lineHeight = FontSize * FontFamily.LineSpacing;
                    double extentHeight = ExtentHeight;
                    double adjustedHeight = Height;

                    while (adjustedHeight - lineHeight > extentHeight)
                    {
                        adjustedHeight -= lineHeight;
                    }

                    Height = adjustedHeight;
                }

                if (!_suppressChangeOpen)
                {
                    bool wasOpen = IsOpen;

                    if (!wasOpen)
                    {
                        _caretPositionOnPopup = _possibleCaretPositionOnPopup;
                        _textOnPopup = Text;
                    }

                    EnsureIntellisenseResults(Text, true, IntellisenseDesiredResultSet.ClosestMatch);

                    if (IsKeyboardFocused && IsKeyboardFocusWithin)
                    {
                        if (!wasOpen && _listBox != null && _listBox.HasItems)
                        {
                            _expectOpen = true;
                            _desiredResultSet = (IntellisenseDesiredResultSet)4;
                            IsOpen = true;
                        }
                    }
                }
                else
                {
                    _suppressChangeOpen = false;
                }

                OnPropertyChanged("Text");

                int maxLines = AllowUserInsertLine ? MaxLines : 1;

                if (LineCount >= maxLines)
                {
                    int caretPosition = CaretIndex;
                    string nText = "";

                    for (int i = 0; i < maxLines; i++)
                    {
                        string lineText = GetLineText(i);

                        if (i + 1 >= maxLines)
                        {
                            if (lineText.EndsWith(Environment.NewLine))
                            {
                                lineText = lineText.Substring(0, lineText.Length - Environment.NewLine.Length);
                            }
                        }

                        nText += lineText;
                    }

                    if (caretPosition > nText.Length) caretPosition = nText.Length;
                    Text = nText;
                    Select(caretPosition, 0);
                }
            }
            catch (InvalidOperationException) { }
        }

        protected virtual void OnAllowMultilinePasteChanged(bool oldValue, bool newValue)
        {
            AcceptsReturn = newValue;
        }

        protected virtual void OnAllowUserInsertLineChanged(bool oldValue, bool newValue)
        {
        }

        protected virtual void OnAllowUserCalculateModeChanged(bool oldValue, bool newValue)
        {
        }

        protected virtual void OnIsInCalculateModeChanged(bool oldValue, bool newValue)
        {
        }

        protected virtual void OnIsOpenChanged(bool oldValue, bool newValue)
        {
            if (newValue)
            {
                if (DesignerProperties.GetIsInDesignMode(this))
                {
                    IsOpen = false;
                    if (_toolTip != null) _toolTip.IsOpen = false;
                }
                else
                {
                    if (_listBox != null)
                    {
                        if (_expectOpen)
                        {
                            _expectOpen = false;
                            if ((int)_desiredResultSet < 4) EnsureIntellisenseResults(Text, true, _desiredResultSet);
                        }
                        else
                        {
                            EnsureIntellisenseResults(Text, true, IntellisenseDesiredResultSet.Default);
                        }

                        if (_listBox.HasItems)
                        {
                            _caretPositionOnPopup = CaretIndex;
                            _textOnPopup = Text;
                            RaiseRoutedEvent(OpenedEvent);
                        }
                        else
                        {
                            IsOpen = false;
                        }
                    }
                    else IsOpen = false;
                }
            }
            else
            {
                EnsureErrorStatus();
                RaiseRoutedEvent(ClosedEvent);
            }
        }

        private void RaiseRoutedEvent(RoutedEvent routedEvent)
        {
            RoutedEventArgs args = new RoutedEventArgs(routedEvent, this);
            RaiseEvent(args);
        }
        #endregion

        #region Provider Handling
        protected virtual void OnIntellisenseProviderChanged(IIntellisenseProvider oldValue, IIntellisenseProvider newValue)
        {
            if (oldValue != null)
            {
                oldValue.Dispose();
                _lastResultInputKey = new KeyValuePair<int, int>(0, 0);
                _lastResultHasError = false;
            }

            if (newValue == null)
            {
                EnsureIntellisenseProvider();
            }
            else
            {
                EnsureIntellisenseResults(Text, true, IntellisenseDesiredResultSet.Default);
            }
        }

        protected virtual IIntellisenseProvider CreateIntellisenseProviderInstance()
        {
            return new DefaultIntellisenseProvider();
        }

        private void EnsureIntellisenseResults(string text, bool forceUpdate, IntellisenseDesiredResultSet desiredResultSet)
        {
            //08.04.2013: Ashley Lewis - Bug 9238
            //if (_listBox == null) _listBox = new ListBox();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                bool calculateMode = false;

                if (AllowUserCalculateMode)
                {
                    if (text.Length > 0 && text[0] == '=')
                    {
                        calculateMode = true;
                        text = text.Substring(1);
                    }

                    IsInCalculateMode = calculateMode;
                }
                else if (IsInCalculateMode) calculateMode = true;


                KeyValuePair<int, int> currentResultInputKey = new KeyValuePair<int, int>(text.Length, text.GetHashCode());

                if (!forceUpdate)
                {
                    if (currentResultInputKey.Key != _lastResultInputKey.Key || currentResultInputKey.Value != _lastResultInputKey.Value)
                    {
                        forceUpdate = true;
                    }
                }

                _lastResultInputKey = currentResultInputKey;

                if (forceUpdate)
                {
                    IIntellisenseProvider provider = IntellisenseProvider;
                    var context = new IntellisenseProviderContext { TextBox = this, FilterType = FilterType, DesiredResultSet = desiredResultSet, InputText = text, CaretPosition = CaretIndex, CaretPositionOnPopup = _caretPositionOnPopup, TextOnPopup = _textOnPopup };

                    if ((context.IsInCalculateMode = calculateMode) && AllowUserCalculateMode)
                    {
                        if (CaretIndex > 0) context.CaretPosition = CaretIndex - 1;

                        if (_textOnPopup.Length > 0 && _textOnPopup[0] == '=')
                        {
                            context.TextOnPopup = _textOnPopup.Substring(1);

                            if (_caretPositionOnPopup > 0)
                            {
                                context.CaretPositionOnPopup = _caretPositionOnPopup - 1;
                            }
                        }
                    }

                    _cachedState = null;

                    IList<IntellisenseProviderResult> results = null;

                    try
                    {
                        results = provider.GetIntellisenseResults(context);
                    }
                    // ReSharper disable EmptyGeneralCatchClause
                    catch
                    // ReSharper restore EmptyGeneralCatchClause
                    {
                        //This try catch is to prevent the intellisense box from ever being crashed from a provider.
                        //This catch is intentionally blanks since if a provider throws an exception the intellisense
                        //box should simbly ignore that provider.
                    }

                    if (results != null && results.Count > 0)
                    {
                        _cachedState = context.State;
                        StringBuilder ttErrorBuilder = new StringBuilder();
                        StringBuilder ttValueBuilder = new StringBuilder();
                        bool cleared = false;
                        bool hasError = false;
                        int errorCount = 0;
                        IntellisenseProviderResult popup = null;

                        for (int i = 0; i < results.Count; i++)
                        {
                            IntellisenseProviderResult currentResult = results[i];

                            if (currentResult.IsError)
                            {
                                hasError = true;

                                ttErrorBuilder.Append(++errorCount);
                                ttErrorBuilder.Append(") ");
                                ttErrorBuilder.AppendLine(currentResult.Description);
                            }


                            if (!currentResult.IsError)
                            {
                                if (!currentResult.IsPopup)
                                {
                                    if (!cleared)
                                    {
                                        cleared = true;
                                        _listBox.Items.Clear();
                                    }

                                    _listBox.Items.Add(currentResult);
                                    ttValueBuilder.AppendLine(currentResult.Name);
                                }
                                else
                                {
                                    popup = currentResult;
                                }
                            }
                        }

                        _lastResultHasError = hasError;
                        ttValueBuilder.Clear();

                        if (popup == null)
                        {
                            _fromPopup = false;
                            if (_lastResultHasError)
                            {
                                _toolTip.Content = ttErrorBuilder.ToString();
                            }
                            else
                            {
                                _toolTip.Content = ttValueBuilder.ToString();
                            }
                        }

                        if (popup != null)
                        {
                            _fromPopup = true;
                            string description = popup.Description;

                            if (_lastResultHasError)
                            {
                                //ttValueBuilder.Clear();
                                ttValueBuilder.AppendLine();
                                ttValueBuilder.AppendLine();
                                description = description + ttValueBuilder.ToString() + ttErrorBuilder.ToString();
                            }

                            _toolTip.Content = description;
                            _toolTip.IsOpen = _forcedOpen = true;
                        }
                        else if (_forcedOpen)
                        {
                            _toolTip.IsOpen = _forcedOpen = false;
                        }

                        if (!cleared)
                        {
                            if (IsOpen)
                            {
                                IsOpen = false;

                                if (popup == null)
                                {
                                    _toolTip.IsOpen = _forcedOpen = false;
                                }
                            }

                            _listBox.Items.Clear();
                        }
                    }
                    else
                    {
                        StringBuilder ttValueBuilder = new StringBuilder();
                        StringBuilder ttErrorBuilder = new StringBuilder();
                        bool hasError = false;
                        int errorCount = 0;

                        for (int i = 0; i < _listBox.Items.Count; i++)
                        {
                            IntellisenseProviderResult currentResult = _listBox.Items[i] as IntellisenseProviderResult;

                            if (currentResult != null)
                            {
                                if (currentResult.IsError)
                                {
                                    hasError = true;

                                    ttErrorBuilder.Append(++errorCount);
                                    ttErrorBuilder.Append(") ");
                                    ttErrorBuilder.AppendLine(currentResult.Description);
                                }


                                //if (!currentResult.IsError && !currentResult.IsPopup)
                                //{
                                //    ttValueBuilder.AppendLine(currentResult.Name);
                                //}
                            }
                        }

                        _lastResultHasError = hasError;
                        _fromPopup = false;

                        if (_lastResultHasError)
                        {
                            _toolTip.Content = ttErrorBuilder.ToString();
                        }
                        else
                        {
                            _toolTip.Content = ttValueBuilder.ToString();
                        }

                        if (_forcedOpen)
                        {
                            _toolTip.IsOpen = _forcedOpen = false;
                        }

                        _lastResultHasError = false;

                        if (IsOpen)
                        {
                            IsOpen = false;
                        }

                        _listBox.Items.Clear();
                    }

                    EnsureErrorStatus();
                }
            }
        }

        private void EnsureIntellisenseProvider()
        {
            if (IntellisenseProvider == null)
            {
                IIntellisenseProvider instance = CreateIntellisenseProviderInstance();

                if (instance == null)
                {
                    throw new InvalidOperationException("CreateIntellisenseProviderInstance cannot return null.");
                }

                IntellisenseProvider = instance;
            }
        }
        #endregion

        #region Validation Handling
        private void EnsureErrorStatus()
        {
            HasError = _lastResultHasError;
        }
        #endregion

        #region Dropdown Handling
        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            if (IsOpen)
            {
                bool originIsListbox = false;

                if (e.OriginalSource is DependencyObject)
                {
                    DependencyObject parent = e.OriginalSource as DependencyObject;

                    if (parent != null)
                    {
                        if (parent is System.Windows.Documents.Run)
                        {
                            parent = ((System.Windows.Documents.Run)parent).Parent;
                        }
                        else
                        {
                            parent = VisualTreeHelper.GetParent(parent);
                        }

                        while (parent != null && !(parent is ListBox))
                        {
                            parent = VisualTreeHelper.GetParent(parent);
                        }

                        if (parent != null)
                        {
                            if (parent == _listBox)
                            {
                                originIsListbox = true;
                            }
                        }
                    }
                }

                if (!originIsListbox)
                {
                    IsOpen = false;

                    if (_forcedOpen)
                    {
                        _toolTip.IsOpen = _forcedOpen = false;
                    }
                }
            }

            base.OnPreviewMouseWheel(e);
        }

        private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
        {
            CloseDropDown(true);
        }

        /// <summary>
        /// Closes the drop down.
        /// </summary>
        private void CloseDropDown(bool closeToolTip)
        {
            if (IsOpen)
            {
                IsOpen = false;
            }

            if (closeToolTip && _toolTip != null)
            {
                _toolTip.IsOpen = _forcedOpen = false;
            }

            ReleaseMouseCapture();
        }
        #endregion

        #region Input Handling
        protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnGotKeyboardFocus(e);

            if (SelectAllOnGotFocus)
            {
                SelectAll();
            }
        }

        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnLostKeyboardFocus(e);

            if (_listBox != null && IsOpen && !IsKeyboardFocusWithin && !_listBox.IsKeyboardFocused && !_listBox.IsKeyboardFocusWithin)
            {
                CloseDropDown(true);
            }

            if (this.WrapInBrackets && !string.IsNullOrWhiteSpace(Text))
            {
                string text = Text;

                if (!text.StartsWith("[["))
                {
                    if (!text.StartsWith("["))
                    {
                        text = string.Concat("[[", text);
                    }
                    else
                    {
                        text = string.Concat("[", text);
                    }
                }

                if (!text.EndsWith("]]"))
                {
                    if (!text.EndsWith("]"))
                    {
                        text = string.Concat(text, "]]");
                    }
                    else
                    {
                        text = string.Concat(text, "]");
                    }
                }
                Text = text;
            }
        }

        public void InsertItem(object item, bool force)
        {
            bool isOpen = IsOpen;
            string appendText = null;
            bool isInsert = false;
            bool expand = false;
            int index = CaretIndex;
            IIntellisenseProvider currentProvider = new DefaultIntellisenseProvider();//Bug 8437

            if (isOpen || force)
            {
                IntellisenseProviderResult intellisenseProviderResult = item as IntellisenseProviderResult;
                if (intellisenseProviderResult != null)
                {
                    currentProvider = intellisenseProviderResult.Provider;//Bug 8437
                }

                object selectedItem = item;

                if (_listBox != null)
                {
                    if (selectedItem is IDataListVerifyPart)
                        appendText = ((IDataListVerifyPart)selectedItem).DisplayValue;
                    else
                        appendText = selectedItem.ToString();

                    isInsert = true;
                    CloseDropDown(false);
                    Focus();
                }
            }

            if (appendText != null)
            {
                string currentText = Text;

                if (isInsert)
                {
                    if (currentProvider.HandlesResultInsertion)//Bug 8437
                    {
                        _suppressChangeOpen = true;
                        IntellisenseProviderContext context = new IntellisenseProviderContext() { CaretPosition = index, InputText = currentText, State = _cachedState, TextBox = this };

                        try
                        {
                            Text = currentProvider.PerformResultInsertion(appendText, context);
                        }
                        // ReSharper disable EmptyGeneralCatchClause
                        catch
                        // ReSharper restore EmptyGeneralCatchClause
                        {
                            //This try catch is to prevent the intellisense box from ever being crashed from a provider.
                            //This catch is intentionally blanks since if a provider throws an exception the intellisense
                            //box should simbly ignore that provider.
                        }
                        
                        Select(context.CaretPositionOnPopup, 0);

                        IsOpen = false;
                        appendText = null;
                    }
                    else
                    {
                        int minimum = Math.Max(0, index - appendText.Length);
                        int foundMinimum = -1;
                        int foundLength = 0;

                        for (int i = index - 1; i >= 0; i--)
                        {
                            if (appendText.StartsWith(currentText.Substring(i, index - i), StringComparison.OrdinalIgnoreCase))
                            {
                                foundMinimum = i;
                                foundLength = index - i;
                            }
                            else if (foundMinimum != -1 || appendText.IndexOf(currentText[i].ToString(), StringComparison.OrdinalIgnoreCase) == -1)
                            {
                                i = -1;
                            }
                        }

                        if (foundMinimum != -1)
                        {
                            appendText = appendText.Remove(0, foundLength);
                        }
                    }
                }

                if (appendText != null)
                {
                    _suppressChangeOpen = true;

                    if (currentText.Length == index)
                    {
                        AppendText(appendText);
                        Select(Text.Length, 0);
                    }
                    else
                    {
                        currentText = currentText.Insert(index, appendText);
                        Text = currentText;
                        Select(index + appendText.Length, 0);
                    }

                    IsOpen = false;
                }
            }

            if (expand)
            {
                double lineHeight = FontSize * FontFamily.LineSpacing;
                Height += lineHeight;
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            bool isOpen = IsOpen;

            if (e.Key == Key.Enter || e.Key == Key.Return || e.Key == Key.Tab)
            {
                string appendText = null;
                bool isInsert = false;
                bool expand = false;
                int index = CaretIndex;

                if (AllowUserInsertLine && !isOpen && e.Key != Key.Tab && e.KeyboardDevice.Modifiers == ModifierKeys.None)
                {
                    if (LineCount < MaxLines)
                    {
                        appendText = Environment.NewLine;
                        expand = true;
                    }
                }

                if (isOpen && e.KeyboardDevice.Modifiers == ModifierKeys.None)
                {
                    object selectedItem = null;

                    if (_listBox != null && (selectedItem = _listBox.SelectedItem) != null)
                    {
                        if (selectedItem is IDataListVerifyPart)
                            appendText = ((IDataListVerifyPart)selectedItem).DisplayValue;
                        else
                            appendText = selectedItem.ToString();

                        isInsert = true;
                        CloseDropDown(false);
                        Focus();
                    }
                }

                if (appendText != null)
                {
                    string currentText = Text;

                    if (isInsert)
                    {
                        IIntellisenseProvider currentProvider = ((IntellisenseProviderResult)_listBox.SelectedItem).Provider;

                        if (currentProvider.HandlesResultInsertion)
                        {
                            _suppressChangeOpen = true;
                            IntellisenseProviderContext context = new IntellisenseProviderContext() { CaretPosition = index, InputText = currentText, State = _cachedState, TextBox = this };

                            try
                            {
                                Text = currentProvider.PerformResultInsertion(appendText, context);
                            }
                            // ReSharper disable EmptyGeneralCatchClause
                            catch
                            // ReSharper restore EmptyGeneralCatchClause
                            {
                                //This try catch is to prevent the intellisense box from ever being crashed from a provider.
                                //This catch is intentionally blanks since if a provider throws an exception the intellisense
                                //box should simbly ignore that provider.
                            }

                            Select(context.CaretPositionOnPopup, 0);

                            IsOpen = false;
                            appendText = null;
                        }
                        else
                        {

                            int minimum = Math.Max(0, index - appendText.Length);
                            int foundMinimum = -1;
                            int foundLength = 0;

                            for (int i = index - 1; i >= 0; i--)
                            {
                                if (appendText.StartsWith(currentText.Substring(i, index - i), StringComparison.OrdinalIgnoreCase))
                                {
                                    foundMinimum = i;
                                    foundLength = index - i;
                                }
                                else if (foundMinimum != -1 || appendText.IndexOf(currentText[i].ToString(), StringComparison.OrdinalIgnoreCase) == -1)
                                {
                                    i = -1;
                                }
                            }

                            if (foundMinimum != -1)
                            {
                                appendText = appendText.Remove(0, foundLength);
                            }
                        }
                    }

                    if (appendText != null)
                    {
                        _suppressChangeOpen = true;

                        if (currentText.Length == index)
                        {
                            AppendText(appendText);
                            Select(Text.Length, 0);
                        }
                        else
                        {
                            currentText = currentText.Insert(index, appendText);
                            Text = currentText;
                            Select(index + appendText.Length, 0);
                        }

                        IsOpen = false;
                    }
                }

                if (expand)
                {
                    double lineHeight = FontSize * FontFamily.LineSpacing;
                    Height += lineHeight;
                }

                if (e.Key != Key.Tab)
                {
                    if ((e.Key == Key.Enter || e.Key == Key.Return) && e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
                    {
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (e.Key == Key.Space && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                if (!isOpen)
                {
                    _expectOpen = true;
                    _desiredResultSet = IntellisenseDesiredResultSet.EntireSet;
                    IsOpen = true;
                }

                e.Handled = true;
            }
            else if (IsListBoxInputKey(e) && isOpen)
            {
                EmulateEventOnListBox(e);
            }
            else if (e.Key == Key.Home || e.Key == Key.End)
                CloseDropDown(true);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Escape)
            {
                CloseDropDown(true);
            }
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            IInputElement directlyOver = Mouse.DirectlyOver;
            bool isItemSelected = false;
            //element.DataContext;
            object context = null;

            if (directlyOver is FrameworkElement)
            {
                FrameworkElement element = directlyOver as FrameworkElement;
                context = element.DataContext;
            }
            else if (directlyOver is FrameworkContentElement)
            {
                FrameworkContentElement element = directlyOver as FrameworkContentElement;
                context = element.DataContext;
            }

            if (context is IntellisenseProviderResult)
            {
                InsertItem(context, false);
                isItemSelected = true;
            }

            if (!isItemSelected)
            {
                base.OnPreviewMouseLeftButtonDown(e);
            }
            else
            {
                e.Handled = true;
            }

            Focus();
        }

        internal void UpdateErrorState()
        {
            EnsureIntellisenseResults(Text, true, _desiredResultSet);
        }
        #endregion

        #region Listbox Handling
        private bool IsListBoxInputKey(KeyEventArgs e)
        {
            return (e.Key == Key.Down || e.Key == Key.Up || e.Key == Key.PageDown || e.Key == Key.PageUp);
        }

        private void EmulateEventOnListBox(KeyEventArgs e)
        {
            if (_listBox != null)
            {
                int count = _listBox.Items.Count;
                int index = _listBox.SelectedIndex;
                bool scrolled = false;

                if (e.Key == Key.Down || e.Key == Key.PageDown)
                {
                    if (count != 0)
                    {
                        if (index == -1)
                        {
                            _listBox.SelectedIndex = 0;
                        }
                        else
                        {
                            int adjust = e.Key == Key.Down ? 1 : 4;
                            adjust = Math.Min(index + adjust, count - 1);

                            if (adjust != index)
                            {
                                _listBox.SelectedIndex = adjust;
                            }
                        }

                        scrolled = true;
                    }
                }
                else
                {
                    if (count != 0)
                    {
                        if (index == -1)
                        {
                            _listBox.SelectedIndex = 0;
                        }
                        else
                        {
                            int adjust = e.Key == Key.Up ? -1 : -4;
                            adjust = Math.Max(index + adjust, 0);

                            if (adjust != index)
                            {
                                _listBox.SelectedIndex = adjust;
                            }
                        }

                        scrolled = true;
                    }
                }

                if (scrolled)
                {
                    ScrollIntoViewCentered(_listBox, _listBox.SelectedItem);

                    //FrameworkElement element = _listBox.ItemContainerGenerator.ContainerFromIndex(_listBox.SelectedIndex) as FrameworkElement;



                    //if (element != null)
                    //{
                    //    element.BringIntoView();
                    //}
                }

                e.Handled = true;
            }
        }
        #endregion
    }
}
