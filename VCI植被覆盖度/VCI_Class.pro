pro VCI_Class,iVCI,otSaveData
  ;;按照制备覆盖度分类  
  ;;1:高 ge0.8,2:中高[0.5:0.8],3：中[0.2:0.5],4：低[0.15:0.2],5:极低lt 0.15
  
;  ;;方法一
;  otSaveData = iVCI
;  otSaveData[*,*] = 0
;  index = where(iVCI ge 0.8,count)
;  if count ne 0 then otSaveData(index) = 1
;  index = where(iVCI ge 0.5 and iVCI lt 0.8,count)
;  if count ne 0 then otSaveData(index) = 2
;  index = where(iVCI ge 0.2 and iVCI lt 0.5,count)
;  if count ne 0 then otSaveData(index) = 3
;  index = where(iVCI ge 0.15 and iVCI lt 0.2,count)
;  if count ne 0 then otSaveData(index) = 4
;  index = where(iVCI lt 0.15,count)
;  if count ne 0 then otSaveData(index) = 5
  
  ;;方法二
  iSize = size(iVCI,/DIMENSIONS)
  iNS = iSize[0]
  iNl = iSize[1]
  otSaveData =fltarr(iSize)
  for ii=0,iNs-1 do begin
    for ij=0,iNl-1 do begin
      if iVCI[ii,ij] lt 1 and iVCI[ii,ij] gt -1 then otSaveData[ii,ij]=0
      if iVCI[ii,ij] ge 0.8 then otSaveData[ii,ij]=1
      if iVCI[ii,ij] lt 0.8 and iVCI[ii,ij] ge 0.5 then otSaveData[ii,ij]=2
      if iVCI[ii,ij] lt 0.5 and iVCI[ii,ij] ge 0.2 then otSaveData[ii,ij]=3
      if iVCI[ii,ij] lt 0.2 and iVCI[ii,ij] ge 0.15 then otSaveData[ii,ij]=4
      if iVCI[ii,ij] lt 0.15  then otSaveData[ii,ij]=5
    endfor
  endfor
end