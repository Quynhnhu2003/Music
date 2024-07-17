
<-- Music Database Context -->
add-migration -context MusicDbContext tên_migration
update-database -context MusicDbContext

<-- Music Identity Database Context -->
Add-Migration CreateIdentitySchema -context MusicIdentityContext -OutputDir Data/IdentityMigrations
update-database -context MusicIdentityContext 
