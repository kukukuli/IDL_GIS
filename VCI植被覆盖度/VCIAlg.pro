pro VCIAlg,otNDVI,strXML,otVCI

;  ;;参数1
;  iNDVI_V = 0.9
;  iNSVI_s = 0.15
   ;NDVI_Alg,otARdata,strXML,otNDVI
  ;;参数2
  index  = where(otNDVI le 1 or otNDVI ge -1,count) ;获取有效值，不计算边框
  iNDVI_V = max(otNDVI(index))
  iNDVI_S = min(otNDVI(index))
  
  ;;植被覆盖度
  otVCI = (otNDVI-iNDVI_S )/(iNDVI_V-iNDVI_S)
end
