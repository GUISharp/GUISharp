/*
 * This file is part of GUISharp Project (https://github.com/GUISharp/GUISharp).
 * Copyright (c) 2021 GUISharp Authors.
 *
 * This library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 3.
 *
 * This library is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this source code of library. 
 * If not, see <http://www.gnu.org/licenses/>.
 */


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
