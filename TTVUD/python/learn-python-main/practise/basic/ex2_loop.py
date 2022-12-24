
with open('draft.txt') as f:
    # lấy nội dung của file dưới dạng một list
    data = f.readlines()
idx = 0 # mốc bắt đầu
length = len(data) # mốc kết thúc
new_content = '' # nội dung mới sẽ ghi vào file mới

while idx < length:
    # tách một dòng thành một list
    line_list = data[idx].split()
    idline = 0
    length_line = len(line_list)
    while idline < length_line:
        if line_list[idline] == 'Kteam':
            # thay thế chữ trước Kteam là How
            line_list[idline - 1] = 'How'
        idline += 1
    # nối lại thành một dòng chuỗi
    new_content += ' '.join(line_list) + '\n'
    idx += 1

with open('kteam.txt', 'w') as new_f:
    # ghi nội dung mới vào file kteam.txt
    new_f.write(new_content)