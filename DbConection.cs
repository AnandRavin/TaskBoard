builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<UserDetails>()
        .HasKey(x => new { x.UserId, x.UserName });

    base.OnModelCreating(modelBuilder);
}

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<ProjectDetails>()
        .HasKey(x => new
        {
            x.ProjectId,
            x.ProjectName
        });

    base.OnModelCreating(modelBuilder);
}