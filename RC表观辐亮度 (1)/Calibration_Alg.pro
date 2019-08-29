;;辐射定标
pro Calibration_Alg,iData,strXML,otSaveData

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

  ;;每个像元辐射定标
  iSize = size(iData,/DIMENSIONS)
  otSaveData = fltarr(iSize)
  iBandNum = iSize[2] ;;获取波段放入iBandNum中
  for ii = 0,iBandNum-1 do begin
    iBand = iData[*,*,ii]
    Coef_GF1,otSensorValue,inYear,ii+1,otGain,otOffset
    RadiometricCalibration,iBand,otGain,otOffset,outRCData   
    otSaveData[*,*,ii] = outRCData
  endfor

end

