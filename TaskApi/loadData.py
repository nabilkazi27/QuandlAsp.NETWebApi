import re
import pandas as p
import quandl as q
import numpy as n
import requests as r
from datetime import date
import json

today = date.today()
todayDate = today.strftime("%Y-%m-%d")
q.ApiConfig.api_key = "WfVLq3diGsH4L9ETp9RV"
myData = q.get("BSE/BOM500325", start_date="1992-01-01", end_date=todayDate)
myData = myData.fillna(0)
myData = myData.reset_index()
myData = n.array(myData)
dataHeader = ['stockDate','stockOpen','stockHigh','stockLow','stockClose','stockWAP','stockNoOfShares','stockNoOfTrades','stockTotalTurnover','stockDeliverableQuantity','stockDeliverableQuantityToTradedQuantityPercent','stockSpreadHL','stockSpreadCO']
def changeData(data):
    transformData = {}
    for index in range(len(data)):
        if(index == 0):
            stockDate = p.to_datetime(data[index]).strftime("%Y-%m-%d")
            transformData[dataHeader[index]] = stockDate
            continue
        if(dataHeader[index]=='stockNoOfShares' or dataHeader[index]=='stockNoOfTrades' or dataHeader[index]=='stockDeliverableQuantity'):
            transformData[dataHeader[index]] = int(data[index])
            continue

        transformData[dataHeader[index]] = data[index]
    return transformData

myData = list(map(changeData,myData))


url = "http://localhost:5000/Stock"

headers = {
  'Content-Type': 'application/json'
}

'''
#For 1000 entries per post request
totalDataLoop = int(n.ceil(len(myData)/1000))

dataLoopCounter = 1
startRange = 0
endRange = -1
responseCount = 0

while(dataLoopCounter<=totalDataLoop):
    startRange = endRange+1

    if(dataLoopCounter==totalDataLoop):
        endRange = len(myData)
    else:
        endRange = dataLoopCounter * 1000

    dataRange = range(startRange,endRange)
    data = [myData[i] for i in dataRange]

    payload = json.dumps(data)

    response = r.request("POST", url, headers=headers, data=payload,verify=False)

    if(response):
        responseCount+=1

    dataLoopCounter+=1


if(responseCount==totalDataLoop):
    print("Data Loaded Successfully")

'''

#For all entry in one post request
payload = json.dumps(myData)

response = r.request("POST", url, headers=headers, data=payload,verify=False)

if(response):
    print("Data Loaded Successfully")