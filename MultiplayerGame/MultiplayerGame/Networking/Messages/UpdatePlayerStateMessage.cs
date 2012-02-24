﻿// -----------------------------------------------------------------------
// <copyright file="UpdatePlayerStateMessage.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Lidgren.Network;
using Lidgren.Network.Xna;
using Microsoft.Xna.Framework;
using MultiplayerGame.Entities;

namespace MultiplayerGame.Networking.Messages
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UpdatePlayerStateMessage : IGameMessage
    {
        #region Constructors and Destructors

        public UpdatePlayerStateMessage(NetIncomingMessage im)
        {
            Decode(im);
        }

        public UpdatePlayerStateMessage()
        {
        }

        public UpdatePlayerStateMessage(Player player)
        {
            Id = player.Id;
            Position = player.SimulationState.Position;
            Velocity = player.SimulationState.Velocity;
            Rotation = player.SimulationState.Rotation;
            MessageTime = NetTime.Now;
        }

        #endregion

        #region Properties

        public long Id { get; set; }

        public double MessageTime { get; set; }

        public Vector2 Position { get; set; }

        public float Rotation { get; set; }

        public Vector2 Velocity { get; set; }

        public GameMessageTypes MessageType
        {
            get { return GameMessageTypes.UpdatePlayerState; }
        }

        #endregion

        #region Public Methods

        public void Decode(NetIncomingMessage im)
        {
            Id = im.ReadInt64();
            MessageTime = im.ReadDouble();
            Position = im.ReadVector2();
            Velocity = im.ReadVector2();
            Rotation = im.ReadSingle();
        }

        public void Encode(NetOutgoingMessage om)
        {
            om.Write(Id);
            om.Write(MessageTime);
            om.Write(Position);
            om.Write(Velocity);
            om.Write(Rotation);
        }

        #endregion
    }
}