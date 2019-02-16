using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMapsApp.Models
{
    public class Meta
    {
        public int Code { get; set; }
        public string RequestId { get; set; }
    }

    public class Filter
    {
        public string Name { get; set; }
        public string Key { get; set; }
    }

    public class SuggestedFilters
    {
        public string Header { get; set; }
        public List<Filter> Filters { get; set; }
    }

    public class Ne
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Sw
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class SuggestedBounds
    {
        public Ne Ne { get; set; }
        public Sw Sw { get; set; }
    }

    public class Item2
    {
        public string Summary { get; set; }
        public string Type { get; set; }
        public string ReasonName { get; set; }
    }

    public class Reasons
    {
        public int Count { get; set; }
        public List<Item2> Items { get; set; }
    }

    public class LabeledLatLng
    {
        public string Label { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Location
    {
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public List<LabeledLatLng> LabeledLatLngs { get; set; }
        public int Distance { get; set; }
        public string Cc { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<string> FormattedAddress { get; set; }
        public string CrossStreet { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
    }

    public class Icon
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string ShortName { get; set; }
        public Icon Icon { get; set; }
        public bool Primary { get; set; }
    }

    public class Photos
    {
        public int Count { get; set; }
        public List<object> Groups { get; set; }
    }

    public class VenuePage
    {
        public string Id { get; set; }
    }

    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public List<Category> Categories { get; set; }
        public Photos Photos { get; set; }
        public VenuePage VenuePage { get; set; }
    }

    public class Item
    {
        public Reasons Reasons { get; set; }
        public Venue Venue { get; set; }
        public string ReferralId { get; set; }
    }

    public class Group
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Response
    {
        public SuggestedFilters SuggestedFilters { get; set; }
        public string HeaderLocation { get; set; }
        public string HeaderFullLocation { get; set; }
        public string HeaderLocationGranularity { get; set; }
        public int TotalResults { get; set; }
        public SuggestedBounds SuggestedBounds { get; set; }
        public List<Group> Groups { get; set; }
    }

    public class RootObject
    {
        public Meta Meta { get; set; }
        public Response Response { get; set; }
    }
}
