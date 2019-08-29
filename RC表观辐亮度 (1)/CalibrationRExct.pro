pro CalibrationRExct,strFile,strXML,strSaveFile

  iData = read_tiff(strFile,GEOTIFF=Geovar,INTERLEAVE=2)
  
  ;;算法
  Calibration_Alg,iData,strXML,otSaveData
  
  Write_tiff,strSaveFile,otSaveData,/float,GEOTIFF=Geovar,PLANARCONFIG=2
end





