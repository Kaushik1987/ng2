using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using sample_core_webapi.Model;

namespace samplecorewebapi.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20170829115125_sample_core_webapi.Model.SchoolContext")]
    partial class sample_core_webapiModelSchoolContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("sample_core_webapi.Model.Standard", b =>
                {
                    b.Property<int>("StandardId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StandardName");

                    b.HasKey("StandardId");

                    b.ToTable("Standards");
                });

            modelBuilder.Entity("sample_core_webapi.Model.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<decimal>("Height");

                    b.Property<byte[]>("Photo");

                    b.Property<int?>("StandardId");

                    b.Property<string>("StudentName");

                    b.Property<float>("Weight");

                    b.HasKey("StudentID");

                    b.HasIndex("StandardId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("sample_core_webapi.Model.Student", b =>
                {
                    b.HasOne("sample_core_webapi.Model.Standard", "Standard")
                        .WithMany("Students")
                        .HasForeignKey("StandardId");
                });
        }
    }
}
