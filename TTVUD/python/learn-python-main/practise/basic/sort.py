lst = [56, 14, 11, 756, 34, 90, 11, 11, 65, 0, 11, 35]
idx = 0
maidx = len(lst) - 1

majdx = len(lst)

while idx < maidx:
    if lst[idx] == 11:
        idx += 1
        continue
    jdx = idx + 1
    while jdx < majdx:
        if lst[jdx] == 11:
            jdx += 1
            continue
        if lst[idx] > lst[jdx]:
            lst[idx], lst[jdx] = lst[jdx], lst[idx]
        jdx += 1
    idx += 1





