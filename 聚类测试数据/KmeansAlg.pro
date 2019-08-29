
pro KmeansAlg_gray, iData, iCenterPoints,iClassNum,otClassData
  iSize = size(iData, /DIMENSIONS)
  iRow = iSize[0]
  iLine = iSize[1]
  
  iCount = 0
  pre_ithresholdValue = 0
  WHILE 1 DO BEGIN
    pre_CenterPoints = iCenterPoints
    tmp = fltarr(iClassNum,iRow,iLine)

    for ic = 0,iClassNum-1 do begin      
      tmp[ic,*,*] = iData[*,*] - iCenterPoints[ic]        
    endfor
    
    ;;��ʽһ�����ڻҶ�ͼ�񣬲���Ҫ��norm,ֱ�ӱȽϻҶ�ֵ֮��Ϳ�����
    weightValue = fltarr(iClassNum,iRow,iLine)
    for i = 0,iRow-1 do begin
      for j = 0,iLine-1 do begin
        pointDis_min = min(abs(tmp[*,i,j]),index)
        weightValue[index,i,j] = abs(tmp[index,i,j])
      endfor
    endfor
    
    ;;计算新中心
    for ic = 0,iClassNum-1 do begin
      isum = total(weightValue[ic,*,*])
      iCenterPoints[ic] = total(iData[*,*]*weightValue[ic,*,*])/isum
    endfor
    
    print,'更新后的中心值'
    print,iCenterPoints
            
   
    ithresholdValue = norm(pre_CenterPoints-iCenterPoints)
    idif = abs(pre_ithresholdValue - ithresholdValue)    
    
    print,'核心点间距离：'
    print,ithresholdValue
    print,'与前核心点距离：'
    print,idif
    
    pre_ithresholdValue = ithresholdValue
    
    if idif lt 0.1 then begin
      break
    endif
       
    iCount++
    print,'迭代次数'+string(iCount)

  ENDWHILE
  
  print,'迭代最终的核：'
  print,iCenterPoints
 
 
  for i = 0,iRow-1 do begin
    for j = 0,iLine-1 do begin
      imax = max(weightValue[*,i,j],index)
      weightValue[0,i,j] = index+1
    endfor
  endfor
  
  otClassData = TEMPORARY(weightValue[0,*,*])  
 
end
