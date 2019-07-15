using System.Collections.Generic;
using System;

public class Location{
    public Location(string streetAddress, string openTime,string closeTime)
    {
        StreetAddress = streetAddress;
        OpenTime = openTime;
        CloseTime = closeTime;
        LocationId = Guid.NewGuid();
    }
  //public int LocationId { get; private set; }
  public Guid LocationId { get; private set; }
  public string StreetAddress {get;private set;}
  public string OpenTime{get;private set;}
  public string CloseTime{get;private set;}
  //TODO: add business logic to account for edits
  public List<Unit> BrewingUnits{get;set;}
}