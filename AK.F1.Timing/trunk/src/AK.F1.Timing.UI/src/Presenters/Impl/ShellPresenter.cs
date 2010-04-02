﻿// Copyright 2010 Andy Kernahan
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Windows;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Microsoft.Practices.ServiceLocation;

using AK.F1.Timing.UI.Utility;

namespace AK.F1.Timing.UI.Presenters
{
    /// <summary>
    /// The <see cref="AK.F1.Timing.UI.Presenters.IShellPresenter"/>.
    /// </summary>
    [Singleton(typeof(IShellPresenter))]
    public class ShellPresenter : PresenterManager, IShellPresenter
    {
        #region Fields.
        
        private IPresenter _dialogueModel;

        #endregion

        #region Public Interface.

        /// <summary>
        /// Initialises a new instance of the <see cref="ShellPresenter"/> class.
        /// </summary>
        /// <param name="serviceLocator">The
        /// <see cref="Microsoft.Practices.ServiceLocation.IServiceLocator"/>.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="serviceLocator"/> is <see langword="null"/>.
        /// </exception>
        public ShellPresenter(IServiceLocator serviceLocator) {

            Guard.NotNull(serviceLocator, "serviceLocator");

            this.Container = serviceLocator;
        }

        /// <inheritdoc/>
        public void Exit() {

            Application.Current.Shutdown();
        }

        /// <inheritdoc/>
        public void Open<T>() where T : IPresenter {

            this.Open(this.Container.GetInstance<T>());
        }

        /// <inheritdoc/>
        public void ShowDialogue<T>(T presenter) where T : IPresenter, ILifecycleNotifier {

            Guard.NotNull(presenter, "presenter");

            presenter.WasShutdown += delegate { this.DialogueModel = null; };
            this.DialogueModel = presenter;
        }

        /// <summary>
        /// Opens the <see cref="AK.F1.Timing.UI.Presenters.IHomePresenter"/>
        /// </summary>
        public void OpenHome() {

            Open<IHomePresenter>();
        }

        /// <inheritdoc/>
        public IPresenter DialogueModel {

            get { return _dialogueModel; }
            private set {
                _dialogueModel = value;
                NotifyOfPropertyChange("DialogueModel");
            }
        }

        /// <summary>
        /// Gets the application's title.
        /// </summary>
        public string ApplicationTitle {

            get { return AssemblyInfoHelper.VersionedTitle; }
        }

        /// <inheritdoc/>
        public IServiceLocator Container { get; private set; }

        #endregion

        #region Protected Interface.

        /// <inheritdoc/>
        protected override void OnActivate() {

            base.OnActivate();

            OpenHome();
        }

        #endregion
    }
}
