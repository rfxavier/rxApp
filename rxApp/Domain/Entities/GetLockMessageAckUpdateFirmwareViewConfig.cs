﻿using System.Data.Entity.ModelConfiguration;

namespace rxApp.Domain.Entities
{
    public class GetLockMessageAckUpdateFirmwareViewConfig: EntityTypeConfiguration<GetLockMessageAckUpdateFirmwareView>
    {
        public GetLockMessageAckUpdateFirmwareViewConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_update_firmware_view");

        }
    }
}