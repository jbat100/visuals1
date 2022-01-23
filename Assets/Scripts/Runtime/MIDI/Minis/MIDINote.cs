namespace Sonosthesia
{
    public readonly struct MIDINote
    {
        public readonly int Channel;
        public readonly int Note;
        public readonly float Velocity;

        public MIDINote(int channel, int note, float velocity)
        {
            Channel = channel;
            Note = note;
            Velocity = velocity;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {nameof(Channel)} {Channel} {nameof(Note)} {Note} {nameof(Velocity)} {Velocity}";
        }
    }
}