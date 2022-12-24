#zip(): gộp 2 list vào 1 list to
a = ['Harry','Messi','CR7']
b = ['Scabber','Hedwig','Son']
for item1, item2 in zip(a,b):
    print(f'{item1} has {item2}')


for index, (item1, item2) in enumerate(zip(a,b)):
    print(f'#{index + 1} - {item1} has {item2}')