namespace BusinessTier
{
    using System;

    public class TScoreRecord
    {
        private string m_actor;
        private double m_maxScore;
        private DateTime m_finishedTime;

        public TScoreRecord(string actor, double maxScore, DateTime finishedTime)
        {
            this.m_actor = actor;
            this.m_maxScore = maxScore;
            this.m_finishedTime = finishedTime;
        }

        public string Actor =>
            this.m_actor;

        public double MaxScore =>
            this.m_maxScore;

        public DateTime FinishedTime =>
            this.m_finishedTime;
    }
}

