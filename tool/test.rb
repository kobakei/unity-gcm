require 'gcm'

API_KEY = "api key";

REGISTRATION_ID = "registration id";

gcm = GCM.new(API_KEY)
registration_ids = [REGISTRATION_ID] # an array of one or more client registration IDs
options = {
  data: {
    score: 123,
    is_first: true,
    foo: "bar"
  },
  collapse_key: "updated_score"
}
response = gcm.send_notification(registration_ids, options)