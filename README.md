#EXE201-razor-

lệnh để tạo database:(nếu trong solution đã có thì không cần dùng lệnh này) 
dotnet ef migrations add InitialCreate

lệnh cập nhật database: 
dotnet ef database update

cách lấy code từ nhánh khác về : 
git checkout ten-nhanh-hien-tai # chuyển về nhánh hiện tại
git fetch origin # lấy code mới từ remote
git merge origin/main # hoặc git rebase origin/main