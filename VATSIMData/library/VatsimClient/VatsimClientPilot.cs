using System;
using System.Collections.Generic;

using VatsimLibrary.VatsimData;

namespace VatsimLibrary.VatsimClient
{
    public class VatsimClientPilot : VatsimClient
    {
        public VatsimClientPlannedFlight Flight { get; set; } = new VatsimClientPlannedFlight();
        public List<VatsimClientPilotSnapshot> Positions { get; set; } = new List<VatsimClientPilotSnapshot>();

        /// <summary>
        /// Examine a new client record to determine if this pilot is logged on
        /// and has an active flight plan.
        /// </summary>
        /// <param name="record"></param>
        public void ProcessVatsimClientPlannedFlight(VatsimClientRecord record)
        {
            if (record != null && record.Clienttype == "PILOT")
            {
                if( this.Flight != null &&
                    this.Flight.Cid == record.Cid &&
                    this.Flight.Callsign == record.Callsign &&
                    this.Flight.PlannedDepairport == record.PlannedDepairport &&
                    this.Flight.PlannedDestairport == record.PlannedDestairport &&
                    this.Flight.TimeLogon == record.TimeLogon)
                {
                    // same flight on record
                }
                else
                {
                    this.Flight = record.GetVatsimClientPlannedFlightFromRecord();
                }
            }
        }

        public void ProcessVatsimClientPilotSnapshot(VatsimClientRecord record)
        {
            if( this.Positions != null &&
                this.Flight != null &&
                this.Flight.Cid == record.Cid &&                
                this.Flight.Callsign == record.Callsign &&
                this.Flight.PlannedDepairport == record.PlannedDepairport &&
                this.Flight.PlannedDestairport == record.PlannedDestairport &&
                this.Flight.TimeLogon == record.TimeLogon)
            {
                // same flight on record
                if(record.Groundspeed != "" && 
                   Convert.ToInt32(record.Groundspeed) > 0)
                {
                    this.Positions.Add(record.GetVatsimClientPilotSnapshotFromRecord());
                }
            }
        }

        public void Update(VatsimClientPilot pilot)
        {
            this.Callsign = pilot.Callsign;
            this.Cid = pilot.Cid;
            this.Clienttype = pilot.Clienttype;
            this.Latitude = pilot.Latitude;
            this.Longitude = pilot.Longitude;
            this.Protrevision = pilot.Protrevision;
            this.Realname = pilot.Realname;
            this.Server = pilot.Server;
            this.TimeLastAtisReceived = pilot.TimeLastAtisReceived;
            this.TimeLogon = pilot.TimeLogon;
        }
    }
}