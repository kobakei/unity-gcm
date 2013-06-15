require 'gcm'

API_KEY = "INPUT YOUR API KEY";

REGISTRATION_ID = "INPUT REGISTRATION ID";

gcm = GCM.new(API_KEY)
registration_ids = [REGISTRATION_ID] # an array of one or more client registration IDs
options = {
  data: {
    score: 123,
    is_first: true,
    foo: "bar",
    # For notification view on status bar
    ticker: "Ticker3",
    content_title: "Content Title",
    content_text: "Content Text"
  },
  collapse_key: "updated_score"
}
response = gcm.send_notification(registration_ids, options)