;;计算数据获取日期到1月1日的天数
pro TianShu,strXML,otDays

  ;;iData = read_tiff(strFile,GEOTIFF=Geovar,INTERLEAVE=2) ;读取高分tiff为数组形式
  
  ;;获取拍摄影像日期
  inNood1 = 'ReceiveTime'
  GETXMLNODEVALUE,strXML,inNood1,otReceiveTime
  itemp = strSplit(otReceiveTime, /EXTRACT)  ;;年月日时间 按空格拆分成两段
  iYMD = strSplit(itemp[0],'-',/EXTRACT)     ;;年月日 按——拆分成三段
  inYear = fix(iYMD[0])
  inMonth = fix(iYMD[1])
  inDay = fix(iYMD[2])
  
  otDays = 0

  ;计算平/闰年的2月的天数
  if  inYear mod 400 eq 0 then begin
    Feb=29  
  endif   else  begin
    Feb=28 
  endelse

  ;计算除了2月以外其他月的天数
  for i=1,1,inMonth-1 do begin
    if i eq 2 then otDays=otDays+Feb  ;加上2月的天数
    ;1-7月，单数月（不可被2整除的月）每月有31天，双数月（可被2整除的月）每月有30天
    if i le 7 then begin
      if i mod 2 eq 0 then  otDays=otDays+30 
      if i mod 2 ne 0 then  otDays=otDays+31         
    endif
    ;8-12月，单数月（不可被2整除的月）每月有30天，双数月（可被2整除的月）每月有31天
    if i gt 7 then begin 
      if i mod 2 eq 0 then otDays=otDays+31  
      if i mod 2 ne 0 then otDays=otDays+30              
    endif
    otDays=otDays+inDay
   endfor

end