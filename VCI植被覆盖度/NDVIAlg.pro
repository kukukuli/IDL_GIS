;;每个像元计算NDVI
pro NDVI_Alg,iData,strXML,otNDVI

  Calibration_Alg,iData,strXML,otRCData
  ReadImage_GF1,otRCData,strXML,otARdata
 
  iData = otARData

  iSize = size(otARData,/DIMENSIONS)
  iNs = iSize[0]
  iNl = iSize[1]
  iNDVI = fltarr(iNs,iNl)
  for ii = 0,iNs-1 do begin
    for ij = 0,iNl-1 do begin
      iAdd = otARData[ii,ij,2] + otARData[ii,ij,3]
      ;;分母为零的情况直接赋无效值
      if iAdd eq 0 then begin
        iNDVI[ii,ij] = 2
      endif else begin
        iNDVI[ii,ij] = (otARData[ii,ij,3] - otARData[ii,ij,2])*1.0/iAdd  ;;*1.0是为了保证浮点型不变
      endelse     
    endfor
  endfor  
  otNDVI = temporary(iNDVI)  
end