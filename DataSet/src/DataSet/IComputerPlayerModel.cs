namespace DataSet
{
    using BusinessTier;
    using System;

    public interface IComputerPlayerModel
    {
        void CreateModel();
        TComputerPlayer[] GetCompterPlayers();
    }
}

