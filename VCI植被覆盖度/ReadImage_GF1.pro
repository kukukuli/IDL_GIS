;;计算表观反射率，需要用到辐射定标结果
pro ReadImage_GF1,otRCData,strXML,otARdata

  ;iData = otRCData ;读取高分tiff为数组形式
   
  ;;获取传感器类型
  inNood = 'SensorID'
  GetXMLNodeValue, strXML, inNood, otSensorValue

  ;;获取拍摄影像日期
  inNood = 'ReceiveTime'
  GetXMLNodeValue, strXML, inNood, otTimeValue
  ;;2015-04-24 11:32:30
  itemp = StrSplit(otTimeValue, /EXTRACT)
  iYMD = StrSplit(itemp[0],'-',/EXTRACT)
  inYear = fix(iYMD[0])

  
  ;获取太阳天顶角
  inNood2 = 'SolarZenith'
  GetXMLNodeValue, strXML, inNood2, otSZValue
  inSZvalue = float(otSZValue)
  
  ;;计算拍摄影像日期距离1月1日 的天数
  TianShu,strXML,otDays
  ;;计算日地距离
  GetDistanceSun2Earth,otDays,d
 
   ;;表观反射率计算
  iSize = size(otRCData,/DIMENSIONS) & iDim = iSize[2]
  otARdata = fltarr(iSize)
  for ii = 0,iDim-1 do begin
    GetEs,otSensorValue,iDim,otEs  ;获取Eλ    
    ApparentReflectanceAlg,otRCData(*,*,ii),d,otEs,inSZvalue,otAReflectance
    otARdata[*,*,ii] = otAReflectance
  endfor
   
end
