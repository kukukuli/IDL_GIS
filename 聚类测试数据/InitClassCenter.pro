
pro InitClassCenter,iData,iClassNum,otInitCenterPoints

  otInitCenterPoints = fltarr(iClassNum)
  imean = mean(iData)
  istd = STDDEV(iData)
  for i = 1,iClassNum do begin      
    otInitCenterPoints[i-1] = imean + istd*(2.0*(i-1)/(iClassNum-1)-1)   
  endfor 
   
end