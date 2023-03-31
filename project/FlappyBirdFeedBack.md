##Nguyễn Trọng Đức - Feed back project flappy bird 

## Cần sửa
- Con chim ở màn hình chính chưa đúng màu với còn chim khi chơi
- Một số hàm để public trong khi có thể để là private
- Hàm Kill Player bị gọi 2 lần -> sai về luồng code, đã sửa luôn
- Khi bấm nhiều lần chơi lại vẫn còn âm thanh phát ra 
- Chưa sử dụng polling để tạo và xóa các cột
- Các biến di chuyển đang để trong prefab -> khó trong việc thay đổi và test, nên để sang 1 khu khác 
- Nút rate và leader board chưa có funtion tương ứng ( tuy đã có gắn hàm tương ứng)
- Các hàm còn chưa được tách, để gộp chung nhiều fuction vào trong 1 hàm.


## Đề xuất
- Không nến gắn trực tiếp biến vào button, nên khai báo button rồi gán sự kiện trong scripts.
- Có thể reset game trực tiếp, không cần load lại scene mỗi khi restart game
- OnTriggerEnter2D và OnCollisionEnter2D được sử dụng thừa, nên sửa dụng phù hợp và dễ hiểu hơn.
- Các biến nên viết tách ra, không nên khai báo chung hết 1 hàng
- Project chia folder đang ổn, không có đề xuất về cách tổ chức project.