﻿using System;
using System.Windows;

namespace Dev2.Studio.Dock
{
	/// <summary>
	/// Static class for dealing with UIElement related members.
	/// </summary>
	public static class UIElementHelper
	{
		#region AddHandler
		/// <summary>
		/// Adds a handler for the specified event on the specified element
		/// </summary>
		/// <param name="element">The element that listens to the event</param>
		/// <param name="routedEvent">The event to listen for</param>
		/// <param name="handler">The delegate to add</param>
		public static void AddHandler(DependencyObject element, RoutedEvent routedEvent, Delegate handler)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			IInputElement inputElement = element as IInputElement;

			if (null != inputElement)
				inputElement.AddHandler(routedEvent, handler);
		}
		#endregion //AddHandler

		#region RaiseEvent
		/// <summary>
		/// Raises an event for the specified event arguments on the specified element
		/// </summary>
		/// <param name="element">The element that listens to the event</param>
		/// <param name="e">The arguments for the routed event to be raised</param>
		public static void RaiseEvent(DependencyObject element, RoutedEventArgs e)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			IInputElement inputElement = element as IInputElement;

			if (null != inputElement)
				inputElement.RaiseEvent(e);
		}
		#endregion //RaiseEvent

		#region RemoveHandler
		/// <summary>
		/// Removes a handler for the specified event on the specified element
		/// </summary>
		/// <param name="element">The element that listens to the event</param>
		/// <param name="routedEvent">The event to unhook from</param>
		/// <param name="handler">The delegate to remove</param>
		public static void RemoveHandler(DependencyObject element, RoutedEvent routedEvent, Delegate handler)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			IInputElement inputElement = element as IInputElement;

			if (null != inputElement)
				inputElement.RemoveHandler(routedEvent, handler);
		}
		#endregion //RemoveHandler
	}
}
