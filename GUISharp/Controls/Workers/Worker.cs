﻿// GUISharp Project
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using GUISharp.WotoProvider.EventHandlers;

namespace GUISharp.Controls.Workers
{
    public sealed class Worker
    {
        //-------------------------------------------------
        #region Constant's Region
        public const string ToStringValue = "GUISharp Worker -- BY wotoTeam";
        #endregion
        //-------------------------------------------------
        #region field's Region
        private Trigger _trigger;
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public Worker(TickHandler<Trigger> _tick, uint _index = 0)
        {
            _trigger = new Trigger(true)
            {
                Index = _index,
            };
			// make sure it's not added before
            _trigger.Tick -= _tick;
            _trigger.Tick += _tick;
        }
        ~Worker()
        {
            if (_trigger != null)
            {
                _trigger.Dispose();
                _trigger = null;
            }
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Method's Region
        public void Start()
        {
            _trigger.Start();
        }
        #endregion
        //-------------------------------------------------
        #region overrided Method's Region
        public override string ToString()
        {
            return ToStringValue;
        }
        #endregion
        //-------------------------------------------------
    }
}
