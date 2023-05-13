namespace ZedGraph
{
    using System;

    public class ScaleState : ICloneable
    {
        private double _min;
        private double _minorStep;
        private double _majorStep;
        private double _max;
        private bool _minAuto;
        private bool _minorStepAuto;
        private bool _majorStepAuto;
        private bool _maxAuto;
        private bool _formatAuto;
        private bool _magAuto;
        private DateUnit _minorUnit;
        private DateUnit _majorUnit;
        private string _format;
        private int _mag;

        public ScaleState(Axis axis)
        {
            this._min = axis._scale._min;
            this._minorStep = axis._scale._minorStep;
            this._majorStep = axis._scale._majorStep;
            this._max = axis._scale._max;
            this._majorUnit = axis._scale._majorUnit;
            this._minorUnit = axis._scale._minorUnit;
            this._format = axis._scale._format;
            this._mag = axis._scale._mag;
            this._minAuto = axis._scale._minAuto;
            this._majorStepAuto = axis._scale._majorStepAuto;
            this._minorStepAuto = axis._scale._minorStepAuto;
            this._maxAuto = axis._scale._maxAuto;
            this._formatAuto = axis._scale._formatAuto;
            this._magAuto = axis._scale._magAuto;
        }

        public ScaleState(ScaleState rhs)
        {
            this._min = rhs._min;
            this._majorStep = rhs._majorStep;
            this._minorStep = rhs._minorStep;
            this._max = rhs._max;
            this._majorUnit = rhs._majorUnit;
            this._minorUnit = rhs._minorUnit;
            this._format = rhs._format;
            this._mag = rhs._mag;
            this._minAuto = rhs._minAuto;
            this._majorStepAuto = rhs._majorStepAuto;
            this._minorStepAuto = rhs._minorStepAuto;
            this._maxAuto = rhs._maxAuto;
            this._formatAuto = rhs._formatAuto;
            this._magAuto = rhs._magAuto;
        }

        public void ApplyScale(Axis axis)
        {
            axis._scale._min = this._min;
            axis._scale._majorStep = this._majorStep;
            axis._scale._minorStep = this._minorStep;
            axis._scale._max = this._max;
            axis._scale._majorUnit = this._majorUnit;
            axis._scale._minorUnit = this._minorUnit;
            axis._scale._format = this._format;
            axis._scale._mag = this._mag;
            axis._scale._minAuto = this._minAuto;
            axis._scale._minorStepAuto = this._minorStepAuto;
            axis._scale._majorStepAuto = this._majorStepAuto;
            axis._scale._maxAuto = this._maxAuto;
            axis._scale._formatAuto = this._formatAuto;
            axis._scale._magAuto = this._magAuto;
        }

        public ScaleState Clone() => 
            new ScaleState(this);

        public bool IsChanged(Axis axis) => 
            (axis._scale._min != this._min) || ((axis._scale._majorStep != this._majorStep) || ((axis._scale._minorStep != this._minorStep) || ((axis._scale._max != this._max) || ((axis._scale._minorUnit != this._minorUnit) || ((axis._scale._majorUnit != this._majorUnit) || ((axis._scale._minAuto != this._minAuto) || ((axis._scale._minorStepAuto != this._minorStepAuto) || ((axis._scale._majorStepAuto != this._majorStepAuto) || (axis._scale._maxAuto != this._maxAuto)))))))));

        object ICloneable.Clone() => 
            this.Clone();
    }
}

