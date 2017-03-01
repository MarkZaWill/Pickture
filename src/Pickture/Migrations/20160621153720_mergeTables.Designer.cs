using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Pickture.Models;

namespace Pickture.Migrations
{
    [DbContext(typeof(PictureDbContext))]
    [Migration("20160621153720_mergeTables")]
    partial class mergeTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pickture.Models.Emotion", b =>
                {
                    b.Property<int>("EmotionId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Contempt");

                    b.Property<float>("Disgust");

                    b.Property<float>("Fear");

                    b.Property<float>("Happiness");

                    b.Property<int>("ImageId");

                    b.Property<float>("Neutral");

                    b.Property<float>("Sadness");

                    b.Property<float>("Surprise");

                    b.HasKey("EmotionId");

                    b.ToTable("Emotions");
                });

            modelBuilder.Entity("Pickture.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Contempt");

                    b.Property<float>("Disgust");

                    b.Property<float>("Fear");

                    b.Property<float>("Happiness");

                    b.Property<string>("ImageURL");

                    b.Property<float>("Neutral");

                    b.Property<float>("Sadness");

                    b.Property<float>("Surprise");

                    b.Property<int>("TakerId");

                    b.HasKey("ImageId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Pickture.Models.Taker", b =>
                {
                    b.Property<int>("TakerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("TakerName");

                    b.HasKey("TakerId");

                    b.ToTable("Takers");
                });
        }
    }
}
