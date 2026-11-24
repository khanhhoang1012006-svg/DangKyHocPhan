
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Danh sách học phần mẫu
var courses = new List<Course>
{
    new(1, "INT101", "Lập trình Java", 40, 35),
    new(2, "INT102", "Cơ sở dữ liệu", 50, 50),
    new(3, "INT103", "Mạng máy tính", 45, 30),
    new(4, "INT104", "Lập trình Web", 40, 20),
    new(5, "INT105", "Trí tuệ nhân tạo", 35, 10)
};

// API kiểm tra hệ thống
app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        message = "Course Registration API is running",
        version = "1.0"
    });
});

// API lấy danh sách học phần
app.MapGet("/courses", () =>
{
    var result = courses.Select(c => new
    {
        c.Id,
        c.Code,
        c.Name,
        c.Capacity,
        c.Registered,
        Available = c.Capacity - c.Registered
    });

    return Results.Ok(result);
});

// API xem chi tiết học phần
app.MapGet("/courses/{id:int}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course is null)
    {
        return Results.NotFound(new
        {
            message = "Không tìm thấy học phần"
        });
    }

    return Results.Ok(new
    {
        course.Id,
        course.Code,
        course.Name,
        course.Capacity,
        course.Registered,
        Available = course.Capacity - course.Registered
    });
});

app.Run();

// Model lưu thông tin học phần
record Course(
    int Id,
    string Code,
    string Name,
    int Capacity,
    int Registered
);
