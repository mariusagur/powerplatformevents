using System.Collections.Generic;
using System.Linq;

namespace powerplatformevents.Models
{
    public class ScheduleModel
    {
        public Dictionary<int, Dictionary<int, Sessions>> MatrixSchedule { get; set; }
        public void GetTrackSchedule(int track)
        {
            var session = new Dictionary<string, Sessions>();
            foreach (var s in MatrixSchedule)
            {
                for (var i = track; i > 0; i--)
                {
                    if (s.Value.ContainsKey(i))
                    {
                        session.Add(s.Value[0].Name, s.Value[i]);
                        i = 0;
                    }
                }
            }
        }

        public void AddSession(string track, Sessions session)
        {
            if (!MatrixSchedule.ContainsKey(session.Timeslot))
            {
                MatrixSchedule.Add(session.Timeslot, new Dictionary<int, Sessions>());
            }
            MatrixSchedule[session.Timeslot].Add(session.Track, session);
        }
    }
}