﻿using System;
using System.Reflection;
using CrudDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;
using Npgsql;

//using Microsoft.Extensions.Logging.Console;

namespace CrudDemo.Data;

public class DemoDbContext : DbContext
{
    public DemoDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseLoggerFactory(loggerFactory);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // modelBuilder.ApplyConfiguration(new EmployeeProjectEntityConfiguration());
        // modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());
        // modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
        // modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());

        var systemEmployeeEntity = new EmployeeEntity
        {
            EmployeeId = Guid.NewGuid(),
            FirstName = "System",
            LastName = "System",
            BirthDate = new DateOnly(1972, 03, 14),
            DepartmentCode = "SUP",
            Email = "",
            PhoneNumber = ""
        };
        modelBuilder.Entity<EmployeeEntity>()
            .HasData(
                systemEmployeeEntity,
                new EmployeeEntity
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = "Yellon",
                    LastName = "Mask",
                    BirthDate = new DateOnly(1972, 03, 14),
                    DepartmentCode = "BOARD",
                    Email = "mars@spacey.com",
                    PhoneNumber = "1112223333"
                },
                new EmployeeEntity
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = "Bill",
                    LastName = "Geyts",
                    BirthDate = new DateOnly(1972, 03, 14),
                    DepartmentCode = "BOARD",
                    Email = "bill.cool@spacey.com",
                    PhoneNumber = "1112223333"
                },
                new EmployeeEntity
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = "Bus",
                    LastName = "Lightyear",
                    BirthDate = new DateOnly(1980, 04, 1),
                    DepartmentCode = "ENG",
                    Email = "toinfinityandbeyond@spacey.com",
                    PhoneNumber = "2223334444"
                },
                new EmployeeEntity
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = "Robert",
                    LastName = "Goddard",
                    BirthDate = new DateOnly(1985, 01, 2),
                    DepartmentCode = "RKT",
                    Email = "iloverockets@spacey.com",
                    PhoneNumber = ""
                },
                new EmployeeEntity
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = "Jeff",
                    LastName = "Beshoes",
                    BirthDate = new DateOnly(1985, 01, 2),
                    DepartmentCode = "LOG",
                    Email = "mynamejeff@spacey.com",
                    PhoneNumber = ""
                }
            );

        modelBuilder.Entity<ProjectEntity>()
            .HasData(
                new ProjectEntity
                {
                    ProjectId = Guid.NewGuid(),
                    Name = "Thaicom",
                    Description = "Thaicom is the name of a series of communications satellites operated from Thailand, and also the name of Thaicom Public Company Limited, which is the company that owns and operates the Thaicom satellite fleet and other telecommunication businesses in Thailand and throughout the Asia-Pacific region. The satellite projects were named Thaicom by the King of Thailand, His Majesty the King Bhumibol Adulyadej, as a symbol of the linkage between Thailand and modern communications technology.",
                    CreatedTimestamp = DateTimeOffset.UtcNow,
                    CreatedByEmployeeId = systemEmployeeEntity.EmployeeId
                },
                new ProjectEntity
                {
                    ProjectId = Guid.NewGuid(),
                    Name = "Iridium NEXT",
                    Description = "In 2017, Iridium began launching Iridium NEXT, a second-generation worldwide network of telecommunications satellites, consisting of 66 active satellites, with another nine in-orbit spares and six on-ground spares. These satellites will incorporate features such as data transmission that were not emphasized in the original design. The constellation will provide L-band data speeds of up to 128 kbit/s to mobile terminals, up to 1.5 Mbit/s to Iridium Pilot marine terminals, and high-speed Ka-band service of up to 8 Mbit/s to fixed/transportable terminals. The next-generation terminals and service are expected to be commercially available by the end of 2018. However, Iridium's proposed use of its next-generation satellites has raised concerns the service will harmfully interfere with GPS devices. The satellites will incorporate a secondary payload for Aireon, a space-qualified ADS-B data receiver. This is for use by air traffic control and, via FlightAware, for use by airlines. A tertiary payload on 58 satellites is a marine AIS ship-tracker receiver, for Canadian company exactEarth Ltd. Iridium can also be used to provide a data link to other satellites in space, enabling command and control of other space assets regardless of the position of ground stations and gateways.",
                    CreatedTimestamp = DateTimeOffset.UtcNow,
                    CreatedByEmployeeId = systemEmployeeEntity.EmployeeId
                },
                new ProjectEntity
                {
                    ProjectId = Guid.NewGuid(),
                    Name = "Commercial Resupply Services",
                    Description = "Commercial Resupply Services (CRS) are a series of contracts awarded by NASA from 2008–2016 for delivery of cargo and supplies to the International Space Station (ISS) on commercially operated spacecraft. The first CRS contracts were signed in 2008 and awarded $1.6 billion to SpaceX for 12 cargo transport missions and $1.9 billion to Orbital Sciences for 8 missions, covering deliveries to 2016. In 2015, NASA extended the Phase 1 contracts by ordering an additional three resupply flights from SpaceX and one from Orbital Sciences. After additional extensions late in 2015, SpaceX is currently scheduled to have a total of 20 missions and Orbital 10. SpaceX began flying resupply missions in 2012, using Dragon cargo spacecraft launched on Falcon 9 rockets from Space Launch Complex 40 at Cape Canaveral Air Force Station, Cape Canaveral, Florida. Orbital Sciences began deliveries in 2013 using Cygnus spacecraft launched on the Antares rocket from Launch Pad 0A at the Mid-Atlantic Regional Spaceport (MARS), Wallops Island, Virginia. A second phase of contracts (known as CRS2) were solicited and proposed in 2014. They were awarded in January 2016 to Orbital ATK, Sierra Nevada Corporation, and SpaceX, for cargo transport flights beginning in 2019 and expected to last through 2024.",
                    CreatedTimestamp = DateTimeOffset.UtcNow,
                    CreatedByEmployeeId = systemEmployeeEntity.EmployeeId
                },
                new ProjectEntity
                {
                    ProjectId = Guid.NewGuid(),
                    Name = "SES",
                    Description = "SES S.A. is a communications satellite owner and operator providing video and data connectivity worldwide to broadcasters, content and internet service providers, mobile and fixed network operators, governments and institutions, with a mission to “connect, enable, and enrich”. SES operates more than 50 geostationary orbit satellites and 16 medium Earth orbit satellites. These comprise the well-known European Astra TV satellites, the O3b data satellites and others with names including AMC, Ciel, NSS, Quetzsat, YahSat and SES.",
                    CreatedTimestamp = DateTimeOffset.UtcNow,
                    CreatedByEmployeeId = systemEmployeeEntity.EmployeeId
                },
                new ProjectEntity
                {
                    ProjectId = Guid.NewGuid(),
                    Name = "JCSAT",
                    Description = "The JSAT constellation is a communication and broadcasting satellite constellation formerly operated by JSAT Corporation and currently by SKY Perfect JSAT Group. It has become the most important commercial constellation in Japan, and the fifth of the world. It has practically amalgamated all private satellite operators in Japan, with only B-SAT left as a local competitor.",
                    CreatedTimestamp = DateTimeOffset.UtcNow,
                    CreatedByEmployeeId = systemEmployeeEntity.EmployeeId
                },
                new ProjectEntity
                {
                    ProjectId = Guid.NewGuid(),
                    Name = "AsiaSat",
                    Description = "Asia Satellite Telecommunications Holdings Limited known as its brand name AsiaSat is a commercial operator of communication spacecraft. AsiaSat is based in Hong Kong but incorporated in Bermuda.",
                    CreatedTimestamp = DateTimeOffset.UtcNow,
                    CreatedByEmployeeId = systemEmployeeEntity.EmployeeId
                },
                new ProjectEntity
                {
                    ProjectId = Guid.NewGuid(),
                    Name = "Orbcomm OG2",
                    Description = "Orbcomm Generation 2 (OG2) second-generation satellites are intended to supplement and eventually replace the current first generation constellation. Eighteen satellites were ordered by 2008—nominally intended to be launched in three groups of six during 2010–2014—and by 2015 have all been launched, on three flights. Orbcomm has options for a further thirty OG2 spacecraft. The satellites were launched by SpaceX on the Falcon 9 launch system. Originally, they were to launch on the smaller Falcon 1e rocket.",
                    CreatedTimestamp = DateTimeOffset.UtcNow,
                    CreatedByEmployeeId = systemEmployeeEntity.EmployeeId
                },
                new ProjectEntity
                {
                    ProjectId = Guid.NewGuid(),
                    Name = "ABS",
                    Description = "ABS, formerly Asia Broadcast Satellite, is a global satellite operator based in Hong Kong and officially incorporated in Bermuda. Its services include direct-to-home and satellite-to-cable TV distribution, cellular services, and internet services. Operating 6 communication satellites, the satellite fleet currently covers 93% of the world’s population including the Americas, Africa, Asia Pacific, Europe, the Middle East, Russia and Commonwealth of Independent States.",
                    CreatedTimestamp = DateTimeOffset.UtcNow,
                    CreatedByEmployeeId = systemEmployeeEntity.EmployeeId
                }
            );
    }

    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
}

internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DemoDbContext>
{
    public DemoDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets("1f970d8a-a0df-4b80-880f-0a5881ad2a62")
            .Build();

        var builder = new DbContextOptionsBuilder<DemoDbContext>();
        //builder.UseSqlServer($"Server=tcp:127.0.0.1,1433;Database=CrudDemoDb;Trusted_Connection=true;integrated security=false;User Id={dbUser};password={dbPasswd}");

        var connectionString = configuration.GetConnectionString("CrudDemoConn");
        Console.WriteLine(connectionString);
        builder.UseNpgsql(connectionString);

        return new DemoDbContext(builder.Options);
    }
}
