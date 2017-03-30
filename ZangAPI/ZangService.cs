﻿using System;
using ZangAPI.Configuration;
using ZangAPI.ConnectionManager;
using ZangAPI.Connectors;

namespace ZangAPI
{
    /// <summary>
    /// Zang service
    /// </summary>
    public class ZangService
    {
        /// <summary>
        /// Gets or sets the HTTP manager.
        /// </summary>
        /// <value>
        /// The HTTP manager.
        /// </value>
        public IHttpManager HttpManager { get; set; }

        /// <summary>
        /// Gets or sets the calls connector.
        /// </summary>
        /// <value>
        /// The calls connector.
        /// </value>
        public CallsConnector CallsConnector { get; set; }

        /// <summary>
        /// Gets or sets the SMS connector.
        /// </summary>
        /// <value>
        /// The SMS connector.
        /// </value>
        public SmsConnector SmsConnector { get; set; }

        //todo ostali konektori

        /// <summary>
        /// Initializes a new instance of the <see cref="ZangService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ZangService(IZangConfiguration configuration)
            : this(new HttpManager(configuration))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZangService"/> class.
        /// </summary>
        /// <param name="httpManager">The HTTP manager.</param>
        public ZangService(IHttpManager httpManager)
        {
            this.HttpManager = httpManager;
            this.InitConnectors();
        }

        /// <summary>
        /// Initializes the connectors.
        /// </summary>
        private void InitConnectors()
        {
            this.CallsConnector = new CallsConnector(this.HttpManager);
            this.SmsConnector = new SmsConnector(this.HttpManager);

            //todo ostali
        }

        /// <summary>
        /// Initializes from configuration.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void InitFromConfig()
        {
            throw new NotImplementedException();
        }
    }
}