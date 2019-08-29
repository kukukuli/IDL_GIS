pro NDVIExct,strFile,strXML,strSaveFile

   iData = read_tiff(strFile,GEOTIFF=Geovar,INTERLEAVE=2) ;读取高分tiff为数组形式
  
;  ;;1.表观辐亮度
  Calibration_Alg,iData,strXML,otRCData   
  ;;2.表观反射率
  ReadImage_GF1,otRCData,strXML,otARData
  ;;NDVI
  NDVI_Alg,otARdata,strXML,otNDVI
 
  Write_tiff,strSaveFile,otNDVI,/float,GEOTIFF=Geovar,PLANARCONFIG=2
end