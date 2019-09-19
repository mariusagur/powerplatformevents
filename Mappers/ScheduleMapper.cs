using System.Collections.Generic;
using System.Linq;
using powerplatformevents.Models;

namespace powerplatformsaturday.Mappers
{
    public class ScheduleMapper
    {
        public static ScheduleModel MapDataToModel(IEnumerable<Sessions> sessions)
        {
            var schedule = new ScheduleModel();
            var numTimeslots = sessions.Select(s => s.Timeslot).Distinct().Count();
            for (int i = 0; i < numTimeslots; i++)
            {
                // for 
                // var looper = true;
                // while (looper){

                // }
            }

            sessions.Select(s => s.Id);
            return new ScheduleModel();
        }
    }
}