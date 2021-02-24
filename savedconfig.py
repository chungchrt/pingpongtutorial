from discord import Webhook, RequestsWebhookAdapter


webhook = Webhook.from_url(
    "https://discord.com/api/webhooks/814103394771271720/QO4yDJwyleylBqUHBISNiRr7xeHgxR9EW5sFn4FNb093sEh7JAHEl5RSyIq8bcHVHikQ",
    adapter=RequestsWebhookAdapter())
idName = 'lohiuyin1234@gmail.com'
password = 'Yoyoyo123!'
chooseDate = 'Wed'

datePos = {"Mon": 38, "Tue": 146, "Wed": 254, "Thu": 364, "Fri": 472, "Sat": 580, "Sun": 688}
clickDate = "Sun"

caps1 = {}
caps1['deviceName'] = '0100'
caps1['platformName'] = "Android"
caps1['platformVersion'] = "8"
# caps['appPackage'] = 'com.foodora.courier'
# caps['appActivity'] ='.login.LoginActivity'

caps2 = {}
caps2['deviceName'] = '0200'
caps2['platformName'] = "Android"
caps2['platformVersion'] = "8"