﻿using PublicTransportation.Domain.DTO.Response;
using PublicTransportation.Domain.Entities;
using PublicTransportation.Application.Extensions;

namespace PublicTransportation.Application.Mappers
{
    public static class LineMapper
    {
        public static LineResponseDTO ToResponseDTO(this Line line)
        {
            var stops = new List<StopResponseDTO>();

            if(!line.LinesStops.IsNullOrEmpty()) 
            {
                foreach (var lineStop in line.LinesStops)
                {
                    stops.Add(lineStop.Stop.ToResponseDTO());
                }
            }

            var vehicles = new List<VehicleResponseDTO>();

            if (!line.Vehicles.IsNullOrEmpty())
            {
                foreach (var vehicle in line.Vehicles)
                {
                    vehicles.Add(vehicle.ToResponseDTO());
                }
            }

            return new LineResponseDTO
            {
                Id = line.Id,
                Name = line.Name,
                Stops = stops,
                Vehicles = vehicles,
            };
        }
        public static ICollection<LineResponseDTO> ToResponseDTO(this ICollection<Line> lines)
        {
            var list = new List<LineResponseDTO>();

            foreach (var line in lines)
                list.Add(line.ToResponseDTO());

            return list;
        }
    }
}